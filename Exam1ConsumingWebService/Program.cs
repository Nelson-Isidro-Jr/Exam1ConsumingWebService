using Newtonsoft.Json;

namespace Exam1ConsumingWebService
{
    internal class Program
    {

        static void Main(string[] args)
        {
            WeatherApiHelper weatherApiHelper = new WeatherApiHelper();

            string json = weatherApiHelper.GetWeatherData();

            WeatherDataJson weatherDataJson = JsonConvert.DeserializeObject<WeatherDataJson>(json);

            Console.WriteLine($"Temperature: {weatherDataJson.main.temp}");
            Console.WriteLine($"Humidity: {weatherDataJson.main.humidity}");
            Console.WriteLine($"Wind Speed: {weatherDataJson.wind.speed}");

        }
    }
}
