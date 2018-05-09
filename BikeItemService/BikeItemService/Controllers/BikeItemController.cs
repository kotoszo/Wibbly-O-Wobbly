using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeItemModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BikeItemService.Controllers
{
    [Route("api/[controller]")]
    public class BikeItemController : Controller
    {
        private readonly BikeItemContext _context;

        public BikeItemController(BikeItemContext context)
        {
            _context = context;
            //if (_context.Suppliers.Count() == 0)
            //{
            //    _context.Suppliers.Add(new Supplier { SupplierName = "SuperSupplier" });
            //    _context.SaveChanges();
            //}
            //if (_context.BikeItems.Count() == 0)
            //{
            //    _context.BikeItems.Add(new BikeItem
            //    {
            //        BikeName = "SuperBike",
            //        Price = 225000,
            //        BikeType = "City",
            //        SupplierId = _context.Suppliers.Find(1).SupplierId
            //    });
            //    _context.SaveChanges();
            //}
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            List<BikeItem> list = new List<BikeItem>();
            list = _context.BikeItems.ToList();
            foreach (var item in list)
            {
                item.Supplier = _context.Suppliers.Find(item.SupplierId);
            }

            return Json(list);
        }


        //bármi alapján keresés


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bike = _context.BikeItems.Find(id);
            if(bike == null)
            {
                return new StatusCodeResult(404);
            }
            bike.Supplier = _context.Suppliers.Find(bike.SupplierId);
            return Json(bike);
        }

        [HttpGet(@"search/supplier/{supplier}")]
        public IActionResult GetBySupplier(string supplier)
        {
            Supplier sup = _context.Suppliers.SingleOrDefault(s => s.SupplierName == supplier);
            if (sup == null)
            {
                return new StatusCodeResult(404);
            }
            int supplierId = _context.Suppliers.Single(s => s.SupplierName == supplier).SupplierId;
            var bikes = _context.BikeItems.Where(x => x.SupplierId == supplierId);
            foreach (var item in bikes)
            {
                item.Supplier = sup;
            }
            return Json(bikes);
        }

        [HttpGet(@"search/type/{type}")]
        public IActionResult GetByType(string type)
        {
            var bikes = _context.BikeItems.Where(x => x.BikeType == type);
            
            foreach (var bike in bikes)
            {
                bike.Supplier = _context.Suppliers.Find(bike.SupplierId);
            }
            return Json(bikes);
        }

        [HttpGet(@"search/price/{min}/{max}")]
        public IActionResult GetByPrice(int min, int max)
        {
            var bikes = _context.BikeItems.Where(x => x.Price >= min && x.Price <= max);

            foreach (var bike in bikes)
            {
                bike.Supplier = _context.Suppliers.Find(bike.SupplierId);
            }
            return Json(bikes);
        }


        //hozzáadni új kerót

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        //megváltoztatni adatot

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //törölni bicót id alapján

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
