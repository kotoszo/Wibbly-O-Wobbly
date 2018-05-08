using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly PaymentContext _context;

        public ValuesController(PaymentContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        //public IEnumerable<Item> Get()
        public IEnumerable<object> Get()
        {
            var items = from A in _context.Orders
                        from B in _context.Items.Where(x => x.OrderId == A.Id).DefaultIfEmpty()
                        select new
                        {
                            OrderId = A.Id,
                            UserId = A.UserId,
                            ItemId = B.ItemId
                        };
            return items;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
