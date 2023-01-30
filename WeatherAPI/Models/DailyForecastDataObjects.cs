using System;
namespace WeatherAPI.Models
{
	public class DailyForecastDataObjects
	{
		public DailyForecastDataObjects()
		{
		}

		public City? city { get; set; }
		public string? cod { get; set; }
		public string? message { get; set; }
		public string? cnt { get; set; }
		public List[]? list { get; set; }
	}

	public class City
	{
		public City()
		{

		}

		public string? id { get; set; }
        public string? name { get; set; }
        public Coord? coord { get; set; }
        public string? country { get; set; }
        public string? population { get; set; }
        public string? timezone { get; set; }
    }

    public class List
	{
		public List()
		{

		}

        public string? dt { get; set; }
        public string? sunrise { get; set; }
        public string? sunset { get; set; }
        public Temp? temp { get; set; }
        public FeelsLike? feelsLike { get; set; }
        public string? pressure { get; set; }
        public string? humidity { get; set; }
        public Weather? weather { get; set; }
        public string? speed { get; set; }
        public string? deg { get; set; }
        public string? gust { get; set; }
        public string? clouds { get; set; }
        public string? pop { get; set; }
        public string? rain { get; set; }
    }

    public class Temp
	{
		public Temp()
		{

		}

        public string? day { get; set; }
        public string? min { get; set; }
        public string? max { get; set; }
        public string? night { get; set; }
        public string? eve { get; set; }
        public string? morn { get; set; }
    }

    public class FeelsLike
	{
		public FeelsLike()
		{

		}

        public string? day { get; set; }
        public string? night { get; set; }
        public string? eve { get; set; }
        public string? morn { get; set; }
    }

}

