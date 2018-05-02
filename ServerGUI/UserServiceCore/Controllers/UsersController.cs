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
            return Json(Program.service.GetAllData().Rows);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(Program.service.GetUserData(id));
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
