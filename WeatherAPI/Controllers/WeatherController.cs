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
        private static string apiKey = "6370395d8e70e092cba97f7184323986";
        public static string city = "Topeka";
        public static string units = "imperial";
        private static string? icon; 
        private string getWeatherByCityURI = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={units}";

        // GET: /<Weather>/
        //public string Index()
        //{
        //    IGetWeatherDataHandler getWeatherData = new GetWeatherData();
        //    return getWeatherData.getCurrentWeather();
        //}

        public async Task<IActionResult> Index()
        {
            WeatherDataObjects? currentWeather;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(getWeatherByCityURI))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    currentWeather = JsonConvert.DeserializeObject<WeatherDataObjects>(apiResponse);

                    if (currentWeather != null)
                    {
                        icon = currentWeather.weather[0].icon;
                        string? weatherIconURI = $"http://openweathermap.org/img/wn/{icon}@2x.png";
                        currentWeather.iconURI = weatherIconURI;
                    }
                }
            }


            return View(currentWeather);
        }
    }
}

