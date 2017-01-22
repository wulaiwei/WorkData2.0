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
using WorkData.EF.Domain.Entity.MySql;

namespace WorkData.EF.Domain.Mapping.MySql
{
    public class MySqlUserMap : EntityTypeConfiguration<MySqlUser>
    {
        public MySqlUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name)
                .HasMaxLength(50);
            
            this.ToTable("user");
            this.Property(t => t.Id).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("NAME");
        }
        }
}