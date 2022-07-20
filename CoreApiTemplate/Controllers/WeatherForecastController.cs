using CoreServices.WeatherForecastModule;
using CoreServices.WeatherForecastModule.Entity;
using Microsoft.AspNetCore.Mvc;

namespace core_api_template.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _service;


    public WeatherForecastController(IWeatherForecastService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _service.GetWeatherForecast();
    }
}

