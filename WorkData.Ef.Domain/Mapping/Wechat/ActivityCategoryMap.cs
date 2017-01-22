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
using System.Data.Entity.ModelConfiguration;
using WorkData.EF.Domain.Entity.Wechat;

namespace WorkData.EF.Domain.Mapping.Wechat
{
    public class ActivityCategoryMap : EntityTypeConfiguration<ActivityCategory>
    {

        public ActivityCategoryMap()
        {
            this
                .HasKey(p => new { p.Id })
                .ToTable("EM_ACTIVITY_CATEGORY", "NGWECHAT");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"ID")
                    ;
            this
                .Property(p => p.ActionCode)
                    .HasColumnName(@"ACTION_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            this
                .Property(p => p.Code)
                    .HasColumnName(@"CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            this
                .Property(p => p.Name)
                    .HasColumnName(@"NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
         
        }
    }
}