using Microsoft.AspNetCore.Builder;
using One.Core.Middleware;
using System;
using System.Collections.Generic;
using System.Text;

namespace One.Core.Extensions
{
    /// <summary>
    /// IApplicationBuilder扩展方法 
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// 注册RequestSetMiddleware中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestSet(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestSetMiddleware>();
        }

        /// <summary>
        /// 注册RequestCountMiddleware中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestCount(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCountMiddleware>();
        }
    }
}
