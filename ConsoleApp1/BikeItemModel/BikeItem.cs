using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeItemModel
{
    public class BikeItem
    {
        public int Id { get; set; }
        public string BikeName { get; set; }
        public float Price { get; set; }
        public string BikeType { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
