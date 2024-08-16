using Newtonsoft.Json;
using System;

namespace Exam1ConsumingWebService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Weather Service");

            Console.Write("Enter your API key: ");
            string apiKey = Console.ReadLine();

            string userInput;

            do
            {
                Console.Write("Enter the city: ");
                string city = Console.ReadLine();
                string cityXml = city;

                try
                {
                    // Fetch and display JSON data
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

                try
                {
                    // Fetch and display XML data
                    WeatherApiHelperXml weatherApiHelperXml = new WeatherApiHelperXml(cityXml, apiKey);
                    string xml = weatherApiHelperXml.GetWeatherDataXml();
                    WeatherDataXml weatherDataXml = weatherApiHelperXml.DeserializeObject<WeatherDataXml>(xml);

                    if (weatherDataXml != null)
                    {
                        Console.WriteLine("\nXML output:");
                        Console.WriteLine($"City: {weatherDataXml.City.Name}");
                        Console.WriteLine($"Temperature: {weatherDataXml.Temperature.Value}°K");
                        Console.WriteLine($"Weather: {weatherDataXml.Weather.Value}\n");
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

                Console.Write("\nWould you like to check another city? (y/n): \n");
                userInput = Console.ReadLine()?.ToLower();

            } while (userInput == "y");

            Console.WriteLine("Thank you for using the Weather Service!");
        }
    }
}
