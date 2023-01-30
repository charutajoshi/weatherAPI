using System;
using Newtonsoft.Json;
using System.Net.Http; 

namespace WeatherAPI.Models.Handlers
{
	public class EstablishConnection
	{
		private static string apiKey = "6370395d8e70e092cba97f7184323986";
		public static string city = "Topeka"; 
		private string getWeatherByCityURI = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

        public EstablishConnection()
		{
            //using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync(getWeatherByCityURI))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //    }
            //}
        }
	}
}