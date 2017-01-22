// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Respository 
// 文件名：SqlHelper.cs
// 创建标识：吴来伟 2016-12-28
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;

namespace WorkData.Respository.Repositories
{
    public class OracleSqlHelper
    {
        /// <summary>
        /// EF SQL 语句返回 dataTable
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet SqlQueryForDataTatable(Database db, string sql)
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
    }
}