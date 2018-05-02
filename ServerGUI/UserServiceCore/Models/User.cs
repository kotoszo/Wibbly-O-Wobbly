using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserServiceCore.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class WebApiDataContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public WebApiDataContext(DbContextOptions<WebApiDataContext> options) : base(options)
        {
        }
    }
}
