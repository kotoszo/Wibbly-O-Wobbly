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
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        HttpClient client = new HttpClient();
        [HttpGet]
        public IActionResult Get()
        {
            return GetHelper("http://localhost:49634/api/orders");
        }

        private IActionResult GetHelper(string uri)
        {
            HttpResponseMessage response = client.GetAsync(uri).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            return new ObjectResult(JsonConvert.DeserializeObject(stringData));
        }
    }
}