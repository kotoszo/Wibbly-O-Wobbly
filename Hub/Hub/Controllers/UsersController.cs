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

        public IEnumerable<User> Get()
        {
            return UserServ.GetAllUser();
        }

        public string Get(int id)
        {
            return UserServ.GetUser(id).ToString();
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
