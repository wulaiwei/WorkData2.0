// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.BLL 
// 文件名：WechatActivityBll.cs
// 创建标识：吴来伟 2016-12-27
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data;
using WorkData.BLL.Interface;
using WorkData.Service.Interface;
using WorkData.Util.Entity;

namespace WorkData.BLL.Impl
{
    public class WechatActivityBll: IWechatActivityBll
    {
        private readonly IWechatActivityService _wechatActivityService;
        public WechatActivityBll(IWechatActivityService wechatActivityService)
        {
            _wechatActivityService = wechatActivityService;
        }

        /// <summary>
        /// 查询结果集
        /// </summary>
        /// <param name="wechatActivity"></param>
        /// <returns></returns>
        public void GetDataTable(WechatActivity wechatActivity)
        {
            var dataSet= _wechatActivityService.GetDataTable(wechatActivity);
            wechatActivity.DataTable = dataSet?.Tables[0];
        }

        public void Add()
        {
            _wechatActivityService.Add();
        }
    }
}