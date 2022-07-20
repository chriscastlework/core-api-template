using CoreServices.WeatherForecastModule.Entity;

namespace CoreGrainInterfaces;


public interface IGetWeatherForecast : Orleans.IGrainWithGuidKey
{
    Task<IEnumerable<WeatherForecast>> SayHello(string greeting);
}
