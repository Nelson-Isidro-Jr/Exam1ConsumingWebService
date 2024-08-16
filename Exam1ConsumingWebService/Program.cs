using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace Exam1ConsumingWebService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to Weather Service\n");

            Console.Write("Enter the city: ");
            string city = Console.ReadLine();
            string cityXml = city;

            Console.Write("Enter your API key: ");
            string apiKey = Console.ReadLine();
            string apiKeyXml = apiKey;
            try
            {           

                WeatherApiHelper weatherApiHelper = new WeatherApiHelper(city, apiKey);

                string json = weatherApiHelper.GetWeatherData();

                WeatherDataJson weatherDataJson = JsonConvert.DeserializeObject<WeatherDataJson>(json);

                if (weatherDataJson != null)
                {
                    Console.WriteLine("\nJSON output:");
                    Console.WriteLine($"Temperature: {weatherDataJson.Main.Temp}°C");
                    Console.WriteLine($"Pressure: {weatherDataJson.Main.Pressure} hPa");
                    Console.WriteLine($"Humidity: {weatherDataJson.Main.Humidity}%\n");
                }
                else
                {
                    Console.WriteLine("Unable to retrieve weather data");
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

            WeatherApiHelperXml weatherApiHelperXml = new WeatherApiHelperXml(cityXml, apiKeyXml);
            string xml = weatherApiHelperXml.GetWeatherDataXml();
            WeatherDataXml weatherDataXml = weatherApiHelperXml.DeserializeObject<WeatherDataXml>(xml);

            if (weatherDataXml != null)
            {
                Console.WriteLine("\nXMl output:");
                Console.WriteLine($"City: {weatherDataXml.City.Name}");
                Console.WriteLine($"Temperature: {weatherDataXml.Temperature.Value}°K");
                Console.WriteLine($"Weather: {weatherDataXml.Weather.Value}");
        
            }
            else
            {
                Console.WriteLine("Unable to retrieve weather data");
            }

        }
    }
}