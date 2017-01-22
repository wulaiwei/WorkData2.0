// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.BLL 
// 文件名：IWechatActivityBll.cs
// 创建标识：吴来伟 2016-12-27
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data;
using WorkData.Util.Entity;

namespace WorkData.BLL.Interface
{
    public interface IWechatActivityBll
    {
        void GetDataTable(WechatActivity wechatActivity);

        void Add();
    }
}