using System;
using UserService.Dummy;
using UserService.Model;
using System.ServiceModel;

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
            string expression = "Name = '" + name + "'";
            var row = factory.Table.Select(String.Format("Name = '{0}'", name))[0];
            if (row != null)
            {
                return new User(
                    (int)row["Id"],
                    (string)row["Name"],
                    (string)row["Email"],
                    (DateTime)row["RegistrationDate"]);
            }
            throw new Exception("Username not found!");
        }

        public bool NewUser(string name, string password, string email)
        {
            return factory.InsertNewUser(name, password, email); 
        }
    }
}
