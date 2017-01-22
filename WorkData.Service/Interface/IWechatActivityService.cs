// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Service 
// 文件名：IWechatActivityService.cs
// 创建标识：吴来伟 2016-12-27
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using WorkData.Dto.Entity;
using WorkData.Util.Entity;

namespace WorkData.Service.Interface
{
    public interface IWechatActivityService
    {
        /// <summary>
        /// DataSet
        /// </summary>
        /// <returns></returns>
        DataSet GetDataTable(WechatActivity wechatActivity);

        void Add();
    }
}