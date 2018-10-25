using Core.DAL.ModelMap;
using Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System;

namespace Core.DAL
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class EntryContext : DbContext
    {
        public EntryContext(DbContextOptions options) : base(options)
        {
            
        }

        /// <summary>
        /// 人员
        /// </summary>
        DbSet<SysUser> SysUsers { get; set; }

        ///// <summary>
        ///// 订单
        ///// </summary>
        //DbSet<Order> Orders { get; set; }
        /// <summary>
        /// 配置数据库连接
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseLazyLoadingProxies().UseSqlServer("");//启动延迟加载
        //}

        /// <summary>
        /// 第一次使用EF功能时执行一次以后不再执行
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<SysUser>().toTable("")
            //modelBuilder.ApplyConfiguration(new )
            modelBuilder.Entity<SysUser>().ToTable("SysUser");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<RecAddress>().ToTable("RecAddress");
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.Entity<Role>().HasKey(a => a.RoleShort);//设置主键
            //modelBuilder.Entity<RecAddress>()
            //    .HasOne(p => p.SysUser)
            //    .WithMany(p => p.RecAddresses)
            //    .OnDelete(DeleteBehavior.Cascade);
            



        }
    }
}
