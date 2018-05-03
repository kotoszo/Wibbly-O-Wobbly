using System;
using System.Data;
using UserServiceCore.Models;

namespace UserServiceCore.Utils
{
    public class UserConverter
    {
        public static User CreateUser(DataRow userRow)
        {
            return new User(
                (int)userRow["id"],
                (string)userRow["name"],
                (string)userRow["email"],
                (DateTime)userRow["registrationdate"]
                );
                
        }
    }
}
