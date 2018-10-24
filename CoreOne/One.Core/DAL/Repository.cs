using Core.DAL;
using One.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace One.Core.DAL
{
    /// <summary>
    /// 数据仓库
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        private EntryContext entryContext;
        public Repository(EntryContext entryContext)
        {
            this.entryContext = entryContext;
        }
    }
}
