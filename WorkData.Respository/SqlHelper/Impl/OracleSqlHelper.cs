// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Respository 
// 文件名：OracleSqlHelper.cs
// 创建标识：吴来伟 2016-12-29
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Oracle.DataAccess.Client;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using WorkData.Respository.SqlHelper.Interface;

namespace WorkData.Respository.SqlHelper.Impl
{
    /// <summary>
    /// Oracle SqlHelper
    /// </summary>
    public class OracleSqlHelper: ISqlHelper
    {
        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(Database db, string sql)
        {
            using (var connection = new OracleConnection(db.Connection.ConnectionString))
            {
                var cmd = new OracleCommand(sql,connection);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。 
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public  object ExecuteScalar(Database db, string sql, params DbParameter[] cmdParms)
        {
            var cmd = new OracleCommand();

            using (var connection = new OracleConnection(db.Connection.ConnectionString))
            {
                PrepareCommand(cmd, connection, null, sql, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// EF SQL 语句返回 dataTable
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet Query(Database db, string sql)
        {
            using (var connection = new OracleConnection(db.Connection.ConnectionString))
            {
                var ds = new DataSet();
                try
                {
                    connection.Open();
                    var command = new OracleDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (OracleException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }


        /// <summary>
        ///     执行查询语句，返回DataSet
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sqlString">查询语句</param>
        /// <param name="cmdParms"></param>
        /// <returns>DataSet</returns>
        public DataSet Query(Database db, string sqlString, params DbParameter[] cmdParms)
        {
            using (var connection = new OracleConnection(db.Connection.ConnectionString))
            {
                var cmd = new OracleCommand();
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                using (var da = new OracleDataAdapter(cmd))
                {
                    var ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (OracleException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(
            OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText,
            DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;

            if (cmdParms != null)
            {
                cmdParms = CheckAndFixSqlQueryParameter(cmd, cmdParms);
                CheckAndFixParameterIndex(cmd, cmdParms);
            }
        }

        /// <summary>
        ///     检查并修复参数化查询 返回参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cmdParms"></param>
        private static OracleParameter[] CheckAndFixSqlQueryParameter(
            OracleCommand cmd, params DbParameter[] cmdParms)
        {
            var returnParamMark = ":ReturnValue";
            if (!Regex.IsMatch(cmd.CommandText, returnParamMark) || ExistsParameter(cmdParms, returnParamMark))
                return null;
            var tempArray = new OracleParameter[cmdParms.Length + 1];
            Array.Copy(cmdParms, tempArray, cmdParms.Length);
            tempArray[tempArray.Length - 1] = new OracleParameter
            {
                ParameterName = returnParamMark,
                OracleDbType = OracleDbType.Int32,
                DbType = DbType.Int32,
                Direction = ParameterDirection.InputOutput
            };

            return tempArray;
        }

        /// <summary>
        ///     修复 Oracle.DataAccess 参数化查询 参数名称无效的问题
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cmdParms"></param>
        private static void CheckAndFixParameterIndex(OracleCommand cmd, params DbParameter[] cmdParms)
        {
            var matchs = Regex.Matches(cmd.CommandText, @":\w+");
            foreach (Match match in matchs)
            {
                foreach (var param in cmdParms)
                {
                    if (param.ParameterName != match.Value) continue;

                    var item = param as OracleParameter;
                    PrepareParameter(item);
                    cmd.Parameters.Add(param);
                    break;
                }
            }
        }

        /// <summary>
        ///     查询参数预处理
        /// </summary>
        /// <param name="param"></param>
        private static void PrepareParameter(OracleParameter param)
        {
            #region 参数类型处理

            if (param.OracleDbType == OracleDbType.BFile)
            {
            }
            if (param.OracleDbType == OracleDbType.Blob)
            {
            }
            if (param.OracleDbType == OracleDbType.Byte)
            {
            }
            if (param.OracleDbType == OracleDbType.Char)
            {
            }
            if (param.OracleDbType == OracleDbType.Clob)
            {
            }
            if (param.OracleDbType == OracleDbType.Date)
            {
                param.DbType = DbType.Date;
            }
            if (param.OracleDbType == OracleDbType.Decimal)
            {
            }
            if (param.OracleDbType == OracleDbType.Double)
            {
            }
            if (param.OracleDbType == OracleDbType.Long)
            {
            }
            if (param.OracleDbType == OracleDbType.LongRaw)
            {
            }
            if (param.OracleDbType == OracleDbType.Int16)
            {
            }
            if (param.OracleDbType == OracleDbType.Int32)
            {
                param.DbType = DbType.Int32;
            }
            if (param.OracleDbType == OracleDbType.Int64)
            {
            }
            if (param.OracleDbType == OracleDbType.IntervalDS)
            {
            }
            if (param.OracleDbType == OracleDbType.IntervalYM)
            {
            }
            if (param.OracleDbType == OracleDbType.NClob)
            {
            }
            if (param.OracleDbType == OracleDbType.NChar)
            {
            }
            if (param.OracleDbType == OracleDbType.NVarchar2)
            {
            }
            if (param.OracleDbType == OracleDbType.Raw)
            {
            }
            if (param.OracleDbType == OracleDbType.RefCursor)
            {
            }
            if (param.OracleDbType == OracleDbType.Single)
            {
            }
            if (param.OracleDbType == OracleDbType.TimeStamp)
            {
            }
            if (param.OracleDbType == OracleDbType.TimeStampLTZ)
            {
            }
            if (param.OracleDbType == OracleDbType.TimeStampTZ)
            {
            }
            if (param.OracleDbType == OracleDbType.Varchar2)
            {
            }
            if (param.OracleDbType == OracleDbType.XmlType)
            {
            }
            if (param.OracleDbType == OracleDbType.Array)
            {
            }
            if (param.OracleDbType == OracleDbType.Object)
            {
            }
            if (param.OracleDbType == OracleDbType.Ref)
            {
            }
            if (param.OracleDbType == OracleDbType.BinaryDouble)
            {
            }
            if (param.OracleDbType == OracleDbType.BinaryFloat)
            {
            }

            #endregion

            #region 参数值处理

            if (param.Value == null)
            {
                param.Value = DBNull.Value;
            }

            #endregion

            #region 参数方向处理

            if (param.ParameterName == ":ReturnValue")
            {
                param.Direction = ParameterDirection.Output;
            }

            #endregion
        }

        /// <summary>
        ///     检查指定参数名称的参数是否存在
        /// </summary>
        /// <param name="cmdParams"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        private static bool ExistsParameter(DbParameter[] cmdParams, string paramName)
        {
            return cmdParams.Any(item => item.ParameterName == paramName);
        }
    }
}