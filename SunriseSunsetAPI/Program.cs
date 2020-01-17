using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SunriseSunsetAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string userCategoryUrl = "https://api.sunrise-sunset.org/json?lat=59.4370&lng=24.7536&date=today";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(userCategoryUrl);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                SunMode sunMode = JsonConvert.DeserializeObject<SunMode>(response);
                Console.WriteLine(sunMode.Status);
                Console.WriteLine($"Sunrise: {sunMode.Results.Sunrise}");
                Console.WriteLine($"Sunset: {sunMode.Results.Sunset}");
                
            }

            Console.ReadLine();
        }
    }
}
