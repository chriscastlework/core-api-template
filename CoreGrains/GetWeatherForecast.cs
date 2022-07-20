using CoreGrainInterfaces;
using CoreServices.WeatherForecastModule;
using CoreServices.WeatherForecastModule.Entity;
using Serilog;

namespace CoreGrains;

public class GetWeatherForecast : Orleans.Grain, IGetWeatherForecast
{
    private readonly ILogger _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public GetWeatherForecast(IWeatherForecastService weatherForecastService, ILogger logger)
    {
        this._logger = logger;
        _weatherForecastService = weatherForecastService;
    }
    Task<IEnumerable<WeatherForecast>> IGetWeatherForecast.SayHello(string greeting)
    {
        _logger.Information("Getting weather forecast!", greeting);
        return Task.FromResult(_weatherForecastService.GetWeatherForecast());
    }
}