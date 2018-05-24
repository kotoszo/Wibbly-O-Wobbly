using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayCore
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegDate { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        public User(int id, string name, string email, DateTime regTime, string password = "kamupw")
        {
            Id = id;
            Name = name;
            Email = email;
            RegDate = regTime.ToString("dd/MM/yyyy");
            Password = password;
        }
    }
}
