// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Respository 
// 文件名：SqlHelperProxy.cs
// 创建标识：吴来伟 2016-12-29
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.Data.Entity;
using WorkData.Respository.SqlHelper.Interface;

namespace WorkData.Respository.SqlHelper
{
    public class SqlHelperProxy: ISqlHelper
    {
        private readonly ISqlHelper _sqlHelper;
        public SqlHelperProxy(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public object ExecuteScalar(Database db, string sql)
        {
            return _sqlHelper.ExecuteScalar(db,sql);
        }

        public object ExecuteScalar(Database db, string sql, params DbParameter[] cmdParms)
        {
            return _sqlHelper.ExecuteScalar(db, sql, cmdParms);
        }

        public DataSet Query(Database db, string sql)
        {
            return _sqlHelper.Query(db, sql);
        }

        public DataSet Query(Database db, string sqlString, params DbParameter[] cmdParms)
        {
            return _sqlHelper.Query(db, sqlString, cmdParms);
        }
    }
}