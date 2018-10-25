using Microsoft.AspNetCore.Http;
using One.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Middleware
{
    /// <summary>
    /// 中间件工厂
    /// </summary>
    public class RequestCountMiddleware : IMiddleware
    {
        /**
         * 中间件工厂里面的构造函数可以指定
         * 非中间件工厂的构造函数必须为RequestDelegate
         * */
        private readonly IUnitOfWork unitOfWork;
        public RequestCountMiddleware(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            return next(context);
        }
    }
}
