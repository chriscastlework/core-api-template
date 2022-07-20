using CoreServices.WeatherForecastModule.Entity;

namespace CoreServices.WeatherForecastModule;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}