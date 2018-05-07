using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StorageHandler;
using System.Data;
using UserServiceCore.Utils;
using UserModel;

namespace UserServiceCore.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            List<User> users = new List<User>();
            
            foreach (DataRow userRow in Program.service.GetAllData().Rows)
            {
                users.Add(UserConverter.CreateUser(userRow));
            }
            return Json(users);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(UserConverter.CreateUser(Program.service.GetUserData(id)));
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            Program.service.Registration(user.Name, user.Email, user.Password);
        }

        // TODO later
        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //// DELETE api/users/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}