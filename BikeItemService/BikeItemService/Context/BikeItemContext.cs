using BikeItemModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeItemService
{
    public class BikeItemContext : DbContext
    {
        public BikeItemContext(DbContextOptions<BikeItemContext> options) : base(options)
        {

        }

        public DbSet<BikeItem> BikeItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
