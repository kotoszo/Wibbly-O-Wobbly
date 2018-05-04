using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        public User(int id, string name, string email, DateTime regTime, string password = "kamupw")
        {
            Id = id;
            Name = name;
            Email = email;
            RegDate = regTime;
            Password = password;
        }
    }
}
