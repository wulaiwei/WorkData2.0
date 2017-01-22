// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Respository 
// 文件名：Business.cs
// 创建标识：吴来伟 2016-12-29
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data.Entity;
using WorkData.Util.Entity;

namespace WorkData.Respository.SqlHelper
{
    /// <summary>
    /// 构建代理
    /// </summary>
    public class SqlHelperBusiness
    {
        public static SqlHelperProxy CreateProxy(Database dataBase, WechatActivity wechatActivity)
        {
            var sqlHelper = SqlDataFactory.GetDynamicSqlHelper(dataBase, wechatActivity.ConStrName);
            var proxy = new SqlHelperProxy(sqlHelper);
            return proxy;
        } 
    }
}