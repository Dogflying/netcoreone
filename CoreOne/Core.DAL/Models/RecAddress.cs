using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Models
{
    /// <summary>
    /// 收货地址
    /// </summary>
    public class RecAddress : BaseEntry
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public int SysUserId { get; set; }
        /// <summary>
        /// 收货姓名
        /// </summary>
        public string RecName { get; set; }

        /// <summary>
        /// 收货电话
        /// </summary>
        public string RecTel { get; set; }

        /// <summary>
        /// 收货邮政编号
        /// </summary>
        public string RecCode { get; set; }

        /// <summary>
        /// 获取对应的人员
        /// </summary>
        public virtual SysUser SysUser { get; set; }
    }
}
