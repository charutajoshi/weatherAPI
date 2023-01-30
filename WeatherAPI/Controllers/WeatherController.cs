﻿using System;
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
        public static string count = "7";
        //private static string? icon;
        private string getDailyForecastURI = $"https://api.openweathermap.org/data/2.5/forecast/daily?q={city}$cnt={count}&appid={apiKey}&units={units}";

        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: /Weather/DailyForecast/
        [HttpGet("/DailyForecast/{dayCount}")]
        public async Task<IActionResult> DailyForecast(int dayCount)
        {
            DailyForecastDataObjects? dailyForecastDataObjects;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(getDailyForecastURI))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dailyForecastDataObjects = JsonConvert.DeserializeObject<DailyForecastDataObjects>(apiResponse);
                }
            }

            return View(dailyForecastDataObjects);
        }

        // GET: /Weather?DaySpan={dayCount}
        [HttpGet("DaySpan/{dayCount}")]
        public async Task<IActionResult> DaySpan(string dayCount)
        {
            using (var httpClient = new HttpClient())
            {
                return Redirect($"/DailyForecast/{Int32.Parse(dayCount)}");
            }
        }
    }
}

