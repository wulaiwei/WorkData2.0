// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。
// 项目名：EasyMan.WeChat
// 文件名：WechatActivity.ActivityCategory.cs
// 创建标识：吴来伟 2017-01-08
// 创建描述：
//
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkData.EF.Domain.Entity.Wechat
{
    /// <summary>
    /// 活动分类
    /// </summary>
    public class ActivityCategory 
    {
        #region Properties

        public int Id
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string ActionCode
        {
            get;
            set;
        }

        #endregion Properties
    }
}