using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.DAL.Models
{
    /// <summary>
    /// 系统人员类
    /// </summary>
    //[Table("SysUser")]
    public class SysUser : BaseEntry
    {
        public SysUser()
        {
            RecAddresses = new HashSet<RecAddress>();//为了防止RecAddresses为空
        }

        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 角色权限简称
        /// </summary>
        public string RoleShort { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual Role Role { get; set; }
        /// <summary>
        /// 地址列表
        /// </summary>
        public virtual ICollection<RecAddress> RecAddresses { get; set; }

        #region 延迟加载
        ////构造函数的名称必须为lazyLoader
        //public SysUser(ILazyLoader lazyLoader)
        //{
        //    LazyLoader = lazyLoader;
        //}
        //private ILazyLoader LazyLoader { get; set; }//接口形式

        ////委托形式
        ////private Post(Action<object, string> lazyLoader)
        ////{
        ////    LazyLoader = lazyLoader;
        ////}
        ////private Action<object, string> LazyLoader { get; set; }

        //ICollection<RecAddress> _addresses;
        //public ICollection<RecAddress> AddressList
        //{
        //    get => LazyLoader.Load(this, ref _addresses);
        //    set => _addresses = value;
        //}
        #endregion

    }
}
