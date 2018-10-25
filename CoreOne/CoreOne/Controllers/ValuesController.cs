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
    [Route("api/[controller]")]
    [ApiController]
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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
    }
}
