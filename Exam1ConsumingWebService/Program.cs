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

                if (weatherDataJson != null)
                {
                    Console.WriteLine("JSON output:\n");
                    Console.WriteLine($"Temperature: {weatherDataJson.main.temp}°C");
                    Console.WriteLine($"Feels Like: {weatherDataJson.main.feels_like}°C");
                    Console.WriteLine($"Minimum Temperature: {weatherDataJson.main.temp_min}°C");
                    Console.WriteLine($"Maximum Temperature: {weatherDataJson.main.temp_max}°C");
                    Console.WriteLine($"Pressure: {weatherDataJson.main.pressure} hPa");
                    Console.WriteLine($"Humidity: {weatherDataJson.main.humidity}%");
                    Console.WriteLine($"Sea Level Pressure: {weatherDataJson.main.sea_level} hPa");
                    Console.WriteLine($"Ground Level Pressure: {weatherDataJson.main.grnd_level} hPa\n");
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