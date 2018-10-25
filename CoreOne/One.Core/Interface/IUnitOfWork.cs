using Core.DAL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Interface
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 异步保存
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 事务
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// 获取订单存储库
        /// </summary>
        IRepository<Order> OrderRepository { get; }

        /// <summary>
        /// 获取人员存储库
        /// </summary>
        IRepository<SysUser> UserRepository { get; }

        /// <summary>
        /// 角色存储库
        /// </summary>
        IRepository<Role> RoleRepository { get; }

        /// <summary>
        /// 收货地址存储库
        /// </summary>
        IRepository<RecAddress> RecAdsRepository { get; }
    }
}
