using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exam1ConsumingWebService
{
    public class WeatherApiHelperXml
    {

        private readonly string _apiURLXml;
        private readonly HttpClient _clientXml;

        public WeatherApiHelperXml(string city, string apiKey)
        {
            _apiURLXml = $"https://api.openweathermap.org/data/2.5/weather?q={city}&mode=xml&appid={apiKey}";
            _clientXml = new HttpClient();
        }
        public string GetWeatherDataXml()
        {
            try
            {
                HttpResponseMessage response = _clientXml.GetAsync(_apiURLXml).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error fetching data from the weather API: {e.Message}");
                throw;
            }
        }
        public T DeserializeObject<T>(string xmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlData))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
