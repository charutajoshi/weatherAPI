using System;
namespace WeatherAPI.Models
{
    public class WeatherDataObjects
    {
        public WeatherDataObjects()
        {

        }

        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string baseArea { get; set; }
        public Main main { get; set; }
        public string visibility { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public string dt { get; set; }
        public Sys sys { get; set; }
        public string timezone { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string cod { get; set; }
        public string iconURI { get; set; }
    }

    public class Coord
    {
        public Coord()
        {

        }

        public string? longitude { get; set; }
        public string? latitude { get; set; }
    }

    public class Weather
    {
        public Weather()
        {

        }

        public string? id { get; set; }
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
    }

    public class Main
    {
        public Main()
        {

        }

        public string? temp { get; set; }
        public string? feels_like { get; set; }
        public string? temp_min { get; set; }
        public string? temp_max { get; set; }
        public string? pressure { get; set; }
        public string? humidity { get; set; }
        public string? sea_level { get; set; }
        public string? grnd_level { get; set; }
    }

    public class Wind
    {
        public Wind()
        {

        }

        public string? speed { get; set; }
        public string? deg { get; set; }
        public string? gust { get; set; }
    }

    public class Rain
    {
        public Rain()
        {

        }

        public string? oneH { get; set; }
    }

    public class Clouds
    {
        public Clouds()
        {

        }

        public string? all { get; set; }
    }

    public class Sys
    {
        public Sys()
        {

        }

        public string? type { get; set; }
        public string? id { get; set; }
        public string? country { get; set; }
        public string? sunrise { get; set; }
        public string? sunset { get; set; }
    }
}

