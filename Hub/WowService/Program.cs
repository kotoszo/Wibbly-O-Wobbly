using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WowService
{
    public class DataObject
    {
        public string Name { get; set; }
    }
    class Program
    {
        //  https://eu.api.battle.net/wow/data/character/races?locale=en_GB&apikey=gxxmuyvuhntfncrwvmb4nkvzd9ygh76b
        private const string URL = "https://eu.api.battle.net/wow/data/character/races";
        private static string urlParameters = "?locale=en_GB&apikey=gxxmuyvuhntfncrwvmb4nkvzd9ygh76b";
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                using (var reader = response.Content.ReadAsStreamAsync/*ReadAsAsync<IEnumerable<DataObject>>*/().Result)
                {
                    
                }
                    //foreach (var d in dataObjects)
                    //{
                    //    Console.WriteLine("{0}", d.Name);
                    //}
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
