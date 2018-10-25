﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DAL.Models
{
    /// <summary>
    /// 基础类
    /// </summary>
    public class BaseEntry
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
