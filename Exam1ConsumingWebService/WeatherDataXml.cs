using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exam1ConsumingWebService
{
    [XmlRoot("current")]
    public class WeatherDataXml
    {
        [XmlElement("city")]
        public City City { get; set; }


        [XmlElement("temperature")]
        public Temperature Temperature { get; set; }

        [XmlElement("feels_like")]
        public FeelsLike FeelsLike { get; set; }

        [XmlElement("humidity")]
        public Humidity Humidity { get; set; }

        [XmlElement("pressure")]
        public Pressure Pressure { get; set; }

        [XmlElement("wind")]
        public XMLWind Wind { get; set; }

        [XmlElement("clouds")]
        public XMLClouds Clouds { get; set; }

        [XmlElement("weather")]
        public XMLWeather Weather { get; set; }

        [XmlElement("lastupdate")]
        public LastUpdate LastUpdate { get; set; }
    }

    public class City
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("coord")]
        public XMLCoord Coord { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("timezone")]
        public int Timezone { get; set; }

        [XmlElement("sun")]
        public Sun Sun { get; set; }
    }

    public class XMLCoord
    {
        [XmlAttribute("lon")]
        public float Lon { get; set; }

        [XmlAttribute("lat")]
        public float Lat { get; set; }
    }

    public class Sun
    {
        [XmlAttribute("rise")]
        public DateTime Rise { get; set; }

        [XmlAttribute("set")]
        public DateTime Set { get; set; }
    }

    public class Temperature
    {
        [XmlAttribute("value")]
        public float Value { get; set; }

        [XmlAttribute("min")]
        public float Min { get; set; }

        [XmlAttribute("max")]
        public float Max { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }

    public class FeelsLike
    {
        [XmlAttribute("value")]
        public float Value { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }

    public class Humidity
    {
        [XmlAttribute("value")]
        public float Value { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }

    public class Pressure
    {
        [XmlAttribute("value")]
        public float Value { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }

    public class XMLWind
    {
        [XmlElement("speed")]
        public WindSpeed Speed { get; set; }

        [XmlElement("gusts")]
        public Gusts? Gusts { get; set; } 

        [XmlElement("direction")]
        public WindDirection Direction { get; set; }
    }

    public class WindSpeed
    {
        [XmlAttribute("value")]
        public float Value { get; set; }

        [XmlAttribute("unit")]
        public string Unit { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class Gusts
    {
        [XmlAttribute("value")]
        public float Value { get; set; }

    }

    public class WindDirection
    {
        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class XMLClouds
    {
        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    public class Visibility
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class Precipitation
    {
        [XmlAttribute("mode")]
        public string Mode { get; set; }
    }

    public class XMLWeather
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("icon")]
        public string Icon { get; set; }
    }

    public class LastUpdate
    {
        [XmlAttribute("value")]
        public DateTime Value { get; set; }
    }
}

