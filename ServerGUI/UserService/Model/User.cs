using Newtonsoft.Json;
using System;
using System.Collections;
using System.Runtime.Serialization;

namespace UserService.Model
{
    //[DataContract] //with this, we get an empty user object in the Hub
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        
        public User()
        {

        }

        public User(int id, string name, string email, DateTime regDate)
        {
            Id = id;
            Name = name;
            Email = email;
            RegDate = regDate;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Name, Email, RegDate);
        }
    }
}
