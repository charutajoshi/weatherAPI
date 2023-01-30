using System;
namespace WeatherAPI.Models.Handlers
{
	public class GetWeatherData : IGetWeatherDataHandler
    {
		public GetWeatherData()
		{
		}

        public string getCurrentWeather()
        {
            return "Test123"; 
        }

        public string getMinuteForecastOneHour()
        {
            return "Test";
        }

        public string getHourlyForecastFourtyEightHours()
        {
            return "Test";
        }

        public string getDailyForecastEightDays()
        {
            return "Test";
        }

        public string getNatlWeatherAlerts()
        {
            return "Test";
        }

        public string getHistoricalData()
        {
            return "Test";
        }
    }
}

