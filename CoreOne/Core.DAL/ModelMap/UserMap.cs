using Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.ModelMap
{
    /// <summary>
    /// 人员表映射关系
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<SysUser>
    {
        public void Configure(EntityTypeBuilder<SysUser> builder)
        {
            builder.HasMany(user => user.RecAddresses)
                 .WithOne(a => a.SysUser) //一对多
                 .HasForeignKey(d => d.SysUserId)  //外键
                 .OnDelete(DeleteBehavior.Cascade); //串联删除
            //builder.HasOne(typeof(Role)).WithOne().HasForeignKey("RoleShort");
            //builder.Property(b=>b.ID)
            //    .HasColumnName
            builder.HasOne(a => a.Role)
                .WithMany(a => a.SysUsers)
                .HasForeignKey(a => a.RoleShort)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
        }
    }
}
