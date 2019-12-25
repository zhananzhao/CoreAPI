using System;
using System.Collections.Generic;
using System.Text;
using CoreAPI.Domains.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Ef;

namespace CoreAPI.Infrastructure.Data.EF.SQL.Mappings.User
{
   public class UserInfoMap:AggregateMapBase<UserInfoEntity>
    {
        protected override void MapTable(EntityTypeBuilder<UserInfoEntity> builder)
        {
            builder.ToTable("tb_User", "dbo");
        }

        protected override void MapProperties(EntityTypeBuilder<UserInfoEntity> builder)
        {
            builder.Property(t => t.UserName).HasColumnName("UserName").IsRequired();
            builder.Property(t => t.Age).HasColumnName("Age");
            builder.Property(t => t.Birthday).HasColumnName("Birthday");
            builder.Property(t => t.Birthday).HasColumnName("Birthday");
            builder.Property(t => t.Addr).HasColumnName("Address");
            builder.Property(t => t.Version).IsRowVersion();
        }

        protected override void MapAssociations(EntityTypeBuilder<UserInfoEntity> builder)
        {
            builder.HasMany(t=>t.UseRoleses).WithOne().HasForeignKey(t=>t.UserId);
        }
        
    }
}
