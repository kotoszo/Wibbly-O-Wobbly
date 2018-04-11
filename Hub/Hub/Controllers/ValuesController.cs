using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel;
using UserService;
using UserService.Model;
using System.Runtime.Serialization;

namespace Hub.Controllers
{
    public class UserController : ApiController
    {
        string address = "net.tcp://localhost:2202/UserService";
        private IUserService _userService;
        public IUserService UserServ
        {
            get
            {
                if(_userService == null)
                {
                    EndpointAddress endPoint = new EndpointAddress(new Uri(address));
                    NetTcpBinding binding = new NetTcpBinding();
                    ChannelFactory<IUserService> factory = new ChannelFactory<IUserService>(binding, address);
                    _userService = factory.CreateChannel();
                }
                return _userService;
            }
            private set { _userService = value; }
        }

        // GET api/values
        public IEnumerable<User> Get()
        {
            return UserServ.GetAllUser();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return UserServ.GetUser(id).ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
