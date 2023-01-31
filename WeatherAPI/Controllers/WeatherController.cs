using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Models.Handlers;
using System.Text.Json;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class WeatherController : Controller
    {
        private static string apiKey = "cd519211468d11d46d67337cae2e64eb";
        public static string city = "Topeka";
        public static string units = "imperial";
        public static string count = "7";
        private static string? icon;
        //private string getDailyForecastURI = $"https://api.openweathermap.org/data/2.5/forecast/daily?q={city}&cnt={count}&appid={apiKey}&units={units}";
        private string getWeatherByCityURI = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={units}";

        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: /Weather/DailyForecast
        //[HttpGet("/DailyForecast")]
        //public async Task<IActionResult> DailyForecast(int dayCount)
        //{
        //    DailyForecastDataObjects? dailyForecastDataObjects;

        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync(getDailyForecastURI))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            dailyForecastDataObjects = JsonConvert.DeserializeObject<DailyForecastDataObjects>(apiResponse);
        //        }
        //    }

        //    return View(dailyForecastDataObjects);
        //}

        // GET: /Weather/DailyForecast?dayCount={int}
        [Route("Weather/DailyForecast")]
        public async Task<IActionResult> DailyForecastForNDays(int dayCount)
        {
            DailyForecastDataObjects? dailyForecastDataObjects;

            using (var httpClient = new HttpClient())
            { 
                using (var response = await httpClient.GetAsync(getWeatherByCityURI))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dailyForecastDataObjects = JsonConvert.DeserializeObject<DailyForecastDataObjects>(apiResponse);
                }

                if (dailyForecastDataObjects != null)
                {
                    dailyForecastDataObjects.cnt = dayCount.ToString(); 
                    if (dailyForecastDataObjects.list is not null)
                    {
                        foreach (var forecast in dailyForecastDataObjects.list)
                        {
                            if (forecast.weather is not null)
                            {
                                icon = forecast.weather.icon;
                                string? weatherIconURI = $"http://openweathermap.org/img/wn/{icon}@2x.png";
                                dailyForecastDataObjects.iconURI = weatherIconURI;
                            }
                        }                        
                    }
                }
            }

            return View(dailyForecastDataObjects);
        }
    }
}

