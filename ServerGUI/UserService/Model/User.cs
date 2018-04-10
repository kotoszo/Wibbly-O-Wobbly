using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Model
{
    [DataContract]
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime RegDate { get; private set; }

        public User(int id, string name, string email, DateTime regDate)
        {
            Id = id;
            Name = name;
            Email = email;
            RegDate = regDate;
        }
    }
}
