using Newtonsoft.Json;

namespace Exam1ConsumingWebService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the city: ");
                string city = Console.ReadLine();

                Console.Write("Enter your API key: ");
                string apiKey = Console.ReadLine();

                WeatherApiHelper weatherApiHelper = new WeatherApiHelper(city, apiKey);

                string json = weatherApiHelper.GetWeatherData();

                WeatherDataJson weatherDataJson = JsonConvert.DeserializeObject<WeatherDataJson>(json);

                if (weatherDataJson != null && weatherDataJson.main != null && weatherDataJson.wind != null)
                {
                    Console.Write("JSON output:\n");
                    Console.WriteLine($"Temperature: {weatherDataJson.main.temp}°C");
                    Console.WriteLine($"Humidity: {weatherDataJson.main.humidity}%");
                    Console.WriteLine($"Wind Speed: {weatherDataJson.wind.speed} m/s\n");
                }
                else
                {
                    Console.WriteLine("Unable to retrieve weather data. Please check the city name or API key.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}