using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using One.Core.Interface;

namespace CoreOne.Controllers
{
    /*
     * 在Startup中设置了默认路由之后这些可以取消掉
     * */
    //[Route("api/[controller]/[action]/")]
    //[ApiController]//可省略
    public class ValuesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            try
            {
                SysUser user = unitOfWork.UserRepository.Get(a => a.ID == 1);
                //var users = unitOfWork.UserRepository.Entities.Include(a => a.RecAddresses).AsNoTracking();//贪婪加载
                //unitOfWork.UserRepository.Entities.Include(a=>a.RecAddresses).ThenInclude(b=>b.)
                //unitOfWork.UserRepository.Entities.Collection
                //unitOfWork.UserRepository.Entities.FromSql
                var users = unitOfWork.UserRepository.Entities.Include(a => a.RecAddresses).Include(a => a.Role).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /*
         * 这些方法不注释会一直跳转到实例化valuescontroller
         * 删除了valuescontroller文件会报错
         * */

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet]
        public ActionResult<SysUser> GetById(int id)
        {
            return unitOfWork.UserRepository.Get(id);
        }
    }
}
