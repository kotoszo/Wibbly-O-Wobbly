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
        

        private IActionResult GetHelper(string uri)
        {
            HttpResponseMessage response = client.GetAsync(uri).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            return new ObjectResult(JsonConvert.DeserializeObject(stringData));
        }
    }

}