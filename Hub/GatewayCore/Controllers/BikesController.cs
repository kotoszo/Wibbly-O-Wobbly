using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GatewayCore.Controllers
{
    //[Produces("application/json")]

    [Route("api/[controller]")]
    public class BikesController : Controller
    {
        HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult GetAll()
        {
            return GetHelper(@"http://localhost:61933/api/bikeitem");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return GetHelper(@"http://localhost:61933/api/bikeitem/" + id);
        }

        [HttpGet(@"search/supplier/{supplier}")]
        public IActionResult GetBySupplier(string supplier)
        {
            return GetHelper(@"http://localhost:61933/api/bikeitem/search/supplier/" + supplier);
        }


        [HttpGet(@"search/type/{type}")]
        public IActionResult GetByType(string type)
        {
            return GetHelper(@"http://localhost:61933/api/bikeitem/search/type/" + type);
        }

        [HttpGet(@"search/price/{min}/{max}")]
        public IActionResult GetByPrice(int min, int max)
        {
            return GetHelper(String.Format(@"http://localhost:61933/api/bikeitem/search/price/{0}/{1}", min, max));
        }

        [HttpGet(@"search/{something}")]
        public IActionResult Search(string something)
        {
            return GetHelper(@"http://localhost:61933/api/bikeitem/search/" + something);
        }


        private IActionResult GetHelper(string uri)
        {
            HttpResponseMessage response = client.GetAsync(uri).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            return new ObjectResult(JsonConvert.DeserializeObject(stringData));
        }
    }

}