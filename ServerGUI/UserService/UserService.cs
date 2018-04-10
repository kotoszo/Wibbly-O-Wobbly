using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UserService.Dummy;
using UserService.Model;

namespace UserService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class UserService : IUserService
    {
        // prop to DbHandler
        UserFactory factory;
        public UserService()
        {
            // DbHandler = new ..()
            factory = new UserFactory();
        }
        /// when want to login
        public User GetUser(string name, string password)
        {
            var row = factory.Table.Select("Name = " + name);
            
            return null;
        }

        public void NewUser(string name, string password, string email, DateTime regDate)
        {
            throw new NotImplementedException();
        }
    }
}
