// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Respository 
// 文件名：MsSqlHelper.cs
// 创建标识：吴来伟 2016-12-29
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
using WorkData.Respository.SqlHelper.Interface;

namespace WorkData.Respository.SqlHelper.Impl
{
    /// <summary>
    /// Sql Server SqlHelper
    /// </summary>
    public class MySqlHelper: ISqlHelper
    {
        /// <summary>
        /// 执行一条返回第一条记录第一列的MySqlCommand命令，通过专用的连接字符串。 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(Database db, string sql)
        {
            using (var connection = new MySqlConnection(db.Connection.ConnectionString))
            {
                var cmd = new MySqlCommand(sql, connection);
                var val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 执行一条返回第一条记录第一列的MySqlCommand命令，通过专用的连接字符串。 
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public object ExecuteScalar(Database db, string sql, params DbParameter[] cmdParms)
        {

            var cmd = new MySqlCommand();

            using (var conn = new MySqlConnection(db.Connection.ConnectionString))
            {

                //通过PrePareCommand方法将参数逐个加入到MySqlCommand的参数集合中
                PrepareCommand(cmd, conn, null, CommandType.Text, sql, cmdParms);
                var val = cmd.ExecuteNonQuery();

                //清空MySqlCommand中的参数列表
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
            using (var connection = new MySqlConnection(db.Connection.ConnectionString))
            {
                var ds = new DataSet();
                try
                {
                    connection.Open();
                    var command = new MySqlDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (OracleException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public DataSet Query(Database db, string sqlString, params DbParameter[] cmdParms)
        {
            using (var connection = new MySqlConnection(db.Connection.ConnectionString))
            {
                var cmd = new MySqlCommand();
                PrepareCommand(cmd, connection, null, CommandType.Text, sqlString, cmdParms);
                using (var da = new MySqlDataAdapter(cmd))
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
        /// <param name="cmd">MySqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">MySqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, DbParameter[] cmdParms)
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms == null) return;
            foreach (var parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }
}