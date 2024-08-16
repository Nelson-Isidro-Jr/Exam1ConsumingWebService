using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1ConsumingWebService
{
    public class WeatherApiHelper
    {
        public string ApiURL = "https://api.openweathermap.org/data/2.5/weather?q=London&appid=9a7b1265b6c6c90a8a55fdd4bde3b142";

        public HttpClient client;

        public WeatherApiHelper()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(ApiURL);
        }

        public string GetWeatherData()
        {
            return client.GetStringAsync(ApiURL).Result;
        }
    }
}
