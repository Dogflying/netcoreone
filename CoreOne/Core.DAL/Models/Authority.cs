using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Models
{
    /// <summary>
    /// 权限类
    /// </summary>
    public class Authority : BaseEntry
    {
        /// <summary>
        /// 权限简称(主键)
        /// </summary>
        public string AutorityShort { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        public string AutorityDec { get; set; }
    }
}
