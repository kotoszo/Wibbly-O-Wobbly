using System;
using UserService.Dummy;
using UserService.Model;
using System.ServiceModel;
using DbHandler;
using System.Data;

namespace UserService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class UserService : IUserService
    {
        DbHandler.DbHandler handler;
        UserFactory factory;
        public UserService()
        {
            handler = new DbHandler.DbHandler();
            
        }
        public int LogIn(string name, string password)
        {
            return handler.loginUser(name, password);
        }
        public User GetUser(string id)
        {
            if(int.TryParse(id, out int intId))
            {
                DataRow row = handler.GetUserData(intId);
                if (row != null)
                {
                    return new User(
                        (int)row["Id"],
                        (string)row["Name"],
                        (string)row["Email"],
                        (DateTime)row["RegistrationDate"]);
                }
            }
            throw new Exception("Username not found!");
        }

        public bool NewUser(string name, string password, string email)
        {
            string hashed = Hasher.GenerateSHA512String(password);
            return handler.Registration(name, email, hashed); 
        }
    }
}
