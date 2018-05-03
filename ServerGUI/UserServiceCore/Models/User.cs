using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserServiceCore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string email, DateTime regTime, string password = "kamupw")
        {
            Id = id;
            Name = name;
            Email = email;
            RegDate = regTime;
            Password = password;
        }
    }
    //public class WebApiDataContext : DbContext
    //{

    //    public DbSet<User> Users { get; set; }

    //    public WebApiDataContext(DbContextOptions<WebApiDataContext> options) : base(options)
    //    {
    //    }
    //}
}
