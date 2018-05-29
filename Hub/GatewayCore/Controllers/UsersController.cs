using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft;
using Newtonsoft.Json;

namespace GatewayCore.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private static HttpClient client = new HttpClient();
        string uri = "http://localhost:61926/api/users/";


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // todo something
            return GetHelper(uri);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(id >= 0)
            {
                return GetHelper(uri + id);
            }
            return new StatusCodeResult(404);
        }

        private IActionResult GetHelper(string uri)
        {
            HttpResponseMessage response = client.GetAsync(uri).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            return new ObjectResult(JsonConvert.DeserializeObject(stringData));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]User user)
        {

            string jsonifiedUser = JsonConvert.SerializeObject(user);
            var response = await client.PostAsync(uri, new StringContent(jsonifiedUser, System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return new StatusCodeResult(201);
            }
            return new StatusCodeResult(409);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]User user)
        {
            string jsonifiedUser = JsonConvert.SerializeObject(user);
            var response = await client.PostAsync(uri + "login", new StringContent(jsonifiedUser, System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var finalResult = response.Content.ReadAsStringAsync().Result;
                return Ok(finalResult);
            }
            return new StatusCodeResult(401);
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
