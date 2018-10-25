using Microsoft.AspNetCore.Http;
using System;
using SimpleInjector;
using System.Collections.Generic;
using System.Text;

namespace One.Core.Middleware
{
    /// <summary>
    /// 基于中间件工厂
    /// </summary>
    public class SimpleInjectorMiddlewareFactory : IMiddlewareFactory
    {
        /// <summary>
        /// 容器
        /// </summary>
        public readonly Container container;

        public SimpleInjectorMiddlewareFactory(Container container)
        {
            this.container = container;
        }

        /// <summary>
        /// 创建中间件
        /// </summary>
        /// <param name="middlewareType"></param>
        /// <returns></returns>
        public IMiddleware Create(Type middlewareType)
        {
            return container.GetInstance(middlewareType) as IMiddleware;
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="middleware"></param>
        public void Release(IMiddleware middleware)
        {
            throw new NotImplementedException();
        }
    }
}
