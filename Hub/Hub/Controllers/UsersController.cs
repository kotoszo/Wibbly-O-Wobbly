using System;
using UserService;
using System.Web.Http;
using UserService.Model;
using System.ServiceModel;
using System.Collections.Generic;

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

        [HttpPost]
        public string Post(Models.FormModel user)
        {
            return "Hello " + user.ToString();
        }

        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
