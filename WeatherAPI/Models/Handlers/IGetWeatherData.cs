using System;
namespace WeatherAPI.Models.Handlers;

public interface IGetWeatherDataHandler
{
	public string getCurrentWeather();
	public string getMinuteForecastOneHour();
	public string getHourlyForecastFourtyEightHours();
	public string getDailyForecastEightDays();
	public string getNatlWeatherAlerts();
	public string getHistoricalData(); 
}

