using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class DailyForecastController : Controller
    {
        private static string apiKey = "6370395d8e70e092cba97f7184323986";
        public static string city = "Topeka";
        public static string units = "imperial";
        public static string count = "7"; 
        //private static string? icon;
        private string getDailyForecastURI = $"https://api.openweathermap.org/data/2.5/forecast/daily?q={city}$cnt={count}&appid={apiKey}&units={units}";

        // GET: /DailyForecast/

        public async Task<IActionResult> Index()
        {
            DailyForecastDataObjects? dailyForecastDataObjects;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(getDailyForecastURI))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dailyForecastDataObjects = JsonConvert.DeserializeObject<DailyForecastDataObjects>(apiResponse);

                    //if (dailyForecastDataObjects != null)
                    //{
                    //    icon = dailyForecastDataObjects.weather[0].icon;
                    //    string? weatherIconURI = $"http://openweathermap.org/img/wn/{icon}@2x.png";
                    //    dailyForecastDataObjects.iconURI = weatherIconURI;
                    //}
                }
            }


            return View(dailyForecastDataObjects);
        }
    }
}

