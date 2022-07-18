using core_api_template.Services.WeatherForecastModule.Entity;

namespace core_api_template.Services.WeatherForecastModule;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}