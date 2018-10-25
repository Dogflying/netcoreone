using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Interface
{
    /// <summary>
    /// 数据仓库接口
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// DataBase
        /// </summary>
        DatabaseFacade DataBase { get; }

        /// <summary>
        /// 无跟踪的实体数据集合
        /// </summary>
        IQueryable<T> Entities { get; }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 异步保存到数据库
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 删除实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        bool Delete(List<T> entities, bool isSaveChange = true);

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        bool Delete(T entity, bool isSaveChange = true);

        /// <summary>
        /// 异步删除实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(List<T> entities, bool isSaveChange = true);
        /// <summary>
        /// 异步删除某个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity, bool isSaveChange = true);

        /// <summary>
        /// 根据主键异步获取单个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// 根据表达式异步获取数据集合
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
        /// <summary>
        /// 根据逐渐获取单个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Get(object id);
        /// <summary>
        /// 根据表达式获取单个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate = null);
        /// <summary>
        /// 根据主键异步获取单个实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<T> GetAsync(object id);

        /// <summary>
        /// 根据表达式异步获取无跟踪的数据上下文集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IQueryable<T>> LoadAsync(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// 实体记录
        /// </summary>
        EntityEntry<T> EntityEntries(T entity);
        /// <summary>
        /// 增加实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        bool Insert(List<T> entities, bool isSaveChange = true);

        /// <summary>
        /// 增加单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        bool Insert(T entity, bool isSaveChange = true);

        /// <summary>
        /// 异步增加实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        Task<bool> InsertAsync(List<T> entities, bool isSaveChange = true);

        /// <summary>
        /// 异步增加单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        Task<bool> InsertAsync(T entity, bool isSaveChange = true);

        /// <summary>
        /// 更新数据集合
        /// </summary>
        /// <param name="entities">数据集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        bool Update(List<T> entities, bool isSaveChange = true);

        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity">单个实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <param name="updatePropertyList">更新字段集合</param>
        /// <returns></returns>
        bool Update(T entity, bool isSaveChange = true, List<string> updatePropertyList = null);

        /// <summary>
        /// 异步更新实体数据集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(List<T> entities, bool isSaveChange = true);

        /// <summary>
        /// 异步更新单个实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange">是否保存</param>
        /// <param name="updatePropertyList">更新字段集合</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity, bool isSaveChange = true, List<string> updatePropertyList = null);
    }
}
