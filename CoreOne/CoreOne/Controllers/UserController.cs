using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreOne.Controllers
{
    //[Route("api/[controller]/[action]/")]
    //[ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}