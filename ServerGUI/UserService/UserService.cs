using System;
using System.Data;
using UserService.Model;
using System.ServiceModel;
using System.Collections.Generic;

namespace UserService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class UserService : IUserService
    {
        DbHandler.DbHandler handler;
        public UserService()
        {
            handler = new DbHandler.DbHandler();
            
        }
        public int LogIn(string name, string password)
        {
            return handler.LoginUser(name, password);
        }
        public List<User> GetUsers()
        {
            var rows = handler.GetAllData();
            List<User> list = new List<User>();
            foreach (var row in rows)
            {
                list.Add(new User(
                        (int)row["Id"],
                        (string)row["Name"],
                        (string)row["Email"],
                        (DateTime)row["RegistrationDate"]));
            }
            return list;
        }
        public User GetUser(int id)
        {
            DataRow row = handler.GetUserData(id);
            if (row != null)
            {
                User user = new User
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Email = (string)row["Email"],
                    RegDate = (DateTime)row["RegistrationDate"]
                };
                return user;
            }
            throw new Exception("Username not found!");
        }
        public bool NewUser(string name, string password, string email)
        {
            string hashed = Hasher.GenerateSHA512String(password);
            return handler.Registration(name, email, hashed); 
        }

        public List<User> GetAllUser()
        {
            var rows = handler.GetAllData();
            List<User> list = new List<User>();
            foreach (var row in rows)
            {
                User user = new User
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Email = (string)row["Email"],
                    RegDate = (DateTime)row["RegistrationDate"]
                };
                list.Add(user);
            }
            return list;
        }
    }
}
