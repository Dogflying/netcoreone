using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Models
{
    /// <summary>
    /// 角色名称
    /// </summary>
    public class Role : BaseEntry
    {
        /// <summary>
        /// 角色缩写(主键)
        /// </summary>
        public string RoleShort { get; set; }

        /// <summary>
        /// 角色名称(中文名)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public string Authorities { get; set; }

        /// <summary>
        /// 是否删除(是:0 否:1)
        /// </summary>
        public int IsDel { get; set; }

        /// <summary>
        /// 此角色的所有人员
        /// </summary>
        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
