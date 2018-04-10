using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UserService.Model;

namespace UserService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class UserService : IUserService
    {
        // prop to DbHandler

        public UserService()
        {

        } 
        /// when want to login
        public User GetUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public void NewUser(string name, string password, string email, DateTime regDate)
        {
            throw new NotImplementedException();
        }
    }
}
