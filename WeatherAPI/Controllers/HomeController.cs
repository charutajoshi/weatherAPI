using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static string apiKey = "6370395d8e70e092cba97f7184323986";
    public static string city = "Topeka";
    public static string units = "imperial";
    private static string? icon;
    private string getWeatherByCityURI = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={units}";

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

