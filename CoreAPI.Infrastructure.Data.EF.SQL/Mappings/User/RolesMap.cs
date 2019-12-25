using System;
using System.Collections.Generic;
using System.Text;
using CoreAPI.Domains.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Ef;

namespace CoreAPI.Infrastructure.Data.EF.SQL.Mappings.User
{
   public class RolesMap:AggregateMapBase<Roles>
    {
        protected override void MapTable(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("tb_Roles", "dbo");
        }
        protected override void MapProperties(EntityTypeBuilder<Roles> builder)
        {
            builder.Property(t => t.UserId);
            builder.Property(t => t.RoleName);
            builder.Property(t => t.CreateTime);
            builder.Property(t => t.Version);
        }
    }
}
