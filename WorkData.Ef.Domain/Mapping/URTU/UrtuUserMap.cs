// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.EF.Domain 
// 文件名：UserMap.cs
// 创建标识：吴来伟 2017-01-19
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WorkData.EF.Domain.Entity.URTU;

namespace WorkData.EF.Domain.Mapping.URTU
{
    public class UrtuUserMap : EntityTypeConfiguration<UrtuUser>
    {
        public UrtuUserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            this.Property(t => t.UserName)
                .HasMaxLength(50);
            
            this.ToTable("USER");
            this.Property(t => t.UserId).HasColumnName("USERID");
            this.Property(t => t.UserName).HasColumnName("USERNAME");
        }
        }
}