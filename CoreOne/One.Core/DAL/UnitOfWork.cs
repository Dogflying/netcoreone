using Core.DAL;
using Core.DAL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using One.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private EntryContext entryContext;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(EntryContext context)
        {
            entryContext = context;
        }

        /// <summary>
        /// 事务操作
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction BeginTransaction()
        {
            var scope = entryContext.Database.BeginTransaction();
            return scope;
        }

        #region 保存
        /// <summary>
        /// 保存整个工作单元的数据操作
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return entryContext.SaveChanges();
        }

        /// <summary>
        /// 异步保存整个工作单元的数据操作
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await entryContext.SaveChangesAsync();
        }
        #endregion

        private IRepository<Order> orderRepository = null;//订单存储库
        private IRepository<SysUser> userRepository = null;//人员存储库
        private IRepository<RecAddress> recAdsRepository = null;//收货地址存储库
        private IRepository<Role> roleRepository = null;//角色存储库
        #region 存储库
        /// <summary>
        /// 获取订单存储库
        /// </summary>
        public IRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new Repository<Order>(entryContext);
                }
                return orderRepository;
            }
        }

        /// <summary>
        /// 获取人员存储库
        /// </summary>
        public IRepository<SysUser> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<SysUser>(entryContext);
                }
                return userRepository;
            }
        }

        /// <summary>
        /// 角色存储库
        /// </summary>
        public IRepository<Role> RoleRepository
        {
            get
            {
                if(roleRepository==null)
                {
                    roleRepository = new Repository<Role>(entryContext);
                }
                return roleRepository;
            }
        }

        /// <summary>
        /// 收货地址存储库
        /// </summary>
        public IRepository<RecAddress> RecAdsRepository
        {
            get
            {
                if (recAdsRepository == null)
                {
                    recAdsRepository = new Repository<RecAddress>(entryContext);
                }
                return recAdsRepository;
            }
        }
        #endregion


        #region 释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entryContext.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion


    }
}
