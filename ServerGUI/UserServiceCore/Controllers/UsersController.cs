using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorageHandler;
using System.Data;

namespace UserServiceCore.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        
        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            var users = Program.service.GetAllData().Rows;
            return Json(users);
            //return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
