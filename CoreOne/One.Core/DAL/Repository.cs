using Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using One.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.DAL
{
    /// <summary>
    /// 数据仓库
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        private EntryContext entryContext;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entryContext"></param>
        public Repository(EntryContext entryContext)
        {
            this.entryContext = entryContext;
        }

        /// <summary>
        /// DataBase
        /// </summary>
        public DatabaseFacade DataBase => entryContext.Database;

        #region 获取
        /// <summary>
        /// 根据主键获取单个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public T Get(object id)
        {
            return entryContext.Set<T>().Find(id);
        }

        /// <summary>
        /// 根据表达式获取单个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            return entryContext.Set<T>().Where(predicate).AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// 根据表达式异步获取单个实体
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await entryContext.Set<T>().Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// 根据主键异步获取单个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<T> GetAsync(object id)
        {
            return await entryContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// 根据表达式异步获取数据集合
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await entryContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 根据表达式异步获取无跟踪的数据上下文集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IQueryable<T>> LoadAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                predicate = c => true;
            return await Task.Run(() => entryContext.Set<T>().Where(predicate).AsNoTracking());
        }

        /// <summary>
        /// 无跟踪的实体数据集合
        /// </summary>
        public IQueryable<T> Entities => entryContext.Set<T>().AsQueryable().AsNoTracking();

        /// <summary>
        /// 实体记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EntityEntry<T> EntityEntries(T entity)
        {
            return entryContext.Entry<T>(entity);
        }
        #endregion

        #region 增加
        /// <summary>
        /// 增加实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public bool Insert(List<T> entities, bool isSaveChange = true)
        {
            entryContext.Set<T>().AddRange(entities);
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// 增加单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public bool Insert(T entity, bool isSaveChange = true)
        {
            entryContext.Set<T>().Add(entity);
            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// 异步增加实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(List<T> entities, bool isSaveChange = true)
        {
            entryContext.Set<T>().AddRange(entities);
            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        /// <summary>
        /// 异步增加单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(T entity, bool isSaveChange = true)
        {
            entryContext.Set<T>().Add(entity);
            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public bool Delete(List<T> entities, bool isSaveChange = true)
        {
            entities.ForEach(entity =>
            {
                entryContext.Set<T>().Attach(entity);
                entryContext.Set<T>().Remove(entity);
            });
            return isSaveChange ? SaveChanges() > 0 : false;
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public bool Delete(T entity, bool isSaveChange = true)
        {
            entryContext.Set<T>().Attach(entity);
            entryContext.Set<T>().Remove(entity);
            return isSaveChange ? SaveChanges() > 0 : false;
        }

        /// <summary>
        /// 异步删除实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(List<T> entities, bool isSaveChange = true)
        {
            entities.ForEach(entity =>
            {
                entryContext.Set<T>().Attach(entity);
                entryContext.Set<T>().Remove(entity);
            });
            return isSaveChange ? await SaveChangesAsync() > 0 : false;
        }

        /// <summary>
        /// 异步删除某个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(T entity, bool isSaveChange = true)
        {
            entryContext.Set<T>().Attach(entity);
            entryContext.Set<T>().Remove(entity);
            return isSaveChange ? await SaveChangesAsync() > 0 : false;
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新数据集合
        /// </summary>
        /// <param name="entities">数据集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public bool Update(List<T> entities, bool isSaveChange = true)
        {
            if (entities == null || entities.Count == 0)
            {
                return false;
            }

            entities.ForEach(c =>
            {
                entryContext.Set<T>().Attach(c);
                entryContext.Entry<T>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            });

            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity">单个实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <param name="updatePropertyList">更新字段集合</param>
        /// <returns></returns>
        public bool Update(T entity, bool isSaveChange = true, List<string> updatePropertyList = null)
        {
            if (entity == null)
            {
                return false;
            }

            entryContext.Set<T>().Attach(entity);
            if (updatePropertyList == null)
            {
                entryContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                updatePropertyList.ForEach(c =>
                {
                    entryContext.Entry(entity).Property(c).IsModified = true;//部分字段更新
                });
            }

            if (isSaveChange)
            {
                return SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// 异步更新实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(List<T> entities, bool isSaveChange = true)
        {
            if (entities == null || entities.Count == 0)
            {
                return false;
            }

            entities.ForEach(c =>
            {
                entryContext.Set<T>().Attach(c);
                entryContext.Entry<T>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            });

            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }

        /// <summary>
        /// 异步更新单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <param name="updatePropertyList">更新字段集合</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(T entity, bool isSaveChange = true, List<string> updatePropertyList = null)
        {
            if (entity == null)
            {
                return false;
            }

            entryContext.Set<T>().Attach(entity);
            if (updatePropertyList == null)
            {
                entryContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                updatePropertyList.ForEach(c =>
                {
                    entryContext.Entry(entity).Property(c).IsModified = true;//部分字段更新
                });
            }

            if (isSaveChange)
            {
                return await SaveChangesAsync() > 0;
            }
            return false;
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return entryContext.SaveChanges();
        }

        /// <summary>
        /// 异步保存到数据库
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await entryContext.SaveChangesAsync();
        }
        #endregion

    }
}
