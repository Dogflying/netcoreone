using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreOne.Controllers
{
    //[Route("api/[controller]/[action]/")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        ILogger<UserController> logger;
        IOptions<MyOptions> options;
        public UserController(ILogger<UserController> logger,IOptions<MyOptions> options)
        {
            this.logger = logger;
            this.options = options;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            logger.LogInformation("This is infomation");
            logger.LogWarning("This is warning");
            logger.LogError("This is errror");
            logger.LogInformation("This is infomation");
            return new string[] { "value1", "value2" };
        }
    }
}