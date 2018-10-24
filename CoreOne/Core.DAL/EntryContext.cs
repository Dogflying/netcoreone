using Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        DbSet<User> Users { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        DbSet<Order> Orders { get; set; }
        ///// <summary>
        ///// 配置数据库连接
        ///// </summary>
        ///// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder); 
        //}

        /// <summary>
        /// 第一次使用EF功能时执行一次以后不再执行
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
