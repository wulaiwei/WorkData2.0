// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Respository 
// 文件名：SqlDataFactory.cs
// 创建标识：吴来伟 2016-12-29
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Batch;
using WorkData.Respository.SqlHelper.Impl;
using WorkData.Respository.SqlHelper.Interface;

namespace WorkData.Respository.SqlHelper
{
    public class SqlDataFactory
    {
        /// <summary>
        /// 工厂
        /// </summary>
        /// <param name="db"></param>
        /// <param name="configString"></param>
        /// <returns></returns>
        public static ISqlHelper GetDynamicSqlHelper(Database db,string configString)
        {
            var providerName= GetProviderName(configString).ToUpper();

            if (providerName.Contains("MYSQL.DATA.MYSQLCLIENT"))
            {
                return new MySqlHelper();
            }

            if (providerName.Contains("SQLCLIENT"))
            {
                return new MsSqlHelper();
            }

            return providerName.Contains("ORACLE") ? 
                new OracleSqlHelper() : 
                null;
        }

        // <summary>  
        // 返回数据提供者  
        // </summary>  
        // <returns>返回数据提供者</returns>  
        private static string GetProviderName(string configString)
        {

            var configStringCollention = ConfigurationManager.ConnectionStrings;
            if (configStringCollention == null || configStringCollention.Count <= 0)
            {
                throw new Exception("web.config 中无连接字符串!");
            }
            ConnectionStringSettings stringSettings = null;
            stringSettings =ConfigurationManager.ConnectionStrings[configString];
            return stringSettings.ProviderName;
        }
    }
}