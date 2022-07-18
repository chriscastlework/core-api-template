using core_api_template.Entities;

namespace core_api_template.Services.WeatherForecastModule;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}