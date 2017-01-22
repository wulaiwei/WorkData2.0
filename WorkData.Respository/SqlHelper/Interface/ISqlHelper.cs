// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Respository 
// 文件名：ISqlHelper.cs
// 创建标识：吴来伟 2016-12-29
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.Data.Entity;
using Oracle.DataAccess.Client;

namespace WorkData.Respository.SqlHelper.Interface
{
    public interface ISqlHelper
    {
        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        object ExecuteScalar(Database db, string sql);

        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        object ExecuteScalar(Database db, string sql, params DbParameter[] cmdParms);

        /// <summary>
        /// EF SQL 语句返回 dataTable
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet Query(Database db, string sql);

        /// <summary>
        ///     执行查询语句，返回DataSet
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sqlString">查询语句</param>
        /// <param name="cmdParms"></param>
        /// <returns>DataSet</returns>
        DataSet Query(Database db, string sqlString, params DbParameter[] cmdParms);
    }
}