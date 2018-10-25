using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Middleware
{
    /// <summary>
    /// 中间件
    /// </summary>
    public class RequestSetMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public RequestSetMiddleware(RequestDelegate next)
        {
            requestDelegate = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await requestDelegate(context);
        }
    }
}
