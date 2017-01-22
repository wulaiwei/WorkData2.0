// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Util 
// 文件名：WechatActivity.cs
// 创建标识：吴来伟 2016-12-29
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data;

namespace WorkData.Util.Entity
{
    public class WechatActivity
    {
        /// <summary>
        /// 连接字符串Name
        /// </summary>
        public string ConStrName { get; set; }

        /// <summary>
        /// SQL
        /// </summary>
        public string  Sql { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 结果集
        /// </summary>
        public DataTable DataTable { get; set; }

    }
}