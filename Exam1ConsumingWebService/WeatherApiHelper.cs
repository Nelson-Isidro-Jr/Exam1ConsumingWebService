using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exam1ConsumingWebService
{
    public class WeatherApiHelper
    {
        private readonly string _apiURL;
        private readonly HttpClient _client;

        public WeatherApiHelper(string city, string apiKey)
        {
            _apiURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            _client = new HttpClient();
        }

        public string GetWeatherData()
        {
            try
            {
                HttpResponseMessage response = _client.GetAsync(_apiURL).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception("City not found. Please check the city name and try again.");
                }
                else
                {
                    throw new Exception($"Unexpected error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error fetching data from the weather API: {e.Message}");
                throw;
            }
        }
    }
}
