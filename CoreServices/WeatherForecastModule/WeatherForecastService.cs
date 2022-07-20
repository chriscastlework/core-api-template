using CoreServices.WeatherForecastModule.Entity;
using Serilog;

namespace CoreServices.WeatherForecastModule;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILogger _logger;

    public WeatherForecastService(ILogger logger)
    {
        _logger = logger;
    }
    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        _logger.Information("Weather Forecast executing...");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToArray();
    }
}