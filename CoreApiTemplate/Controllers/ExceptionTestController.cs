using core_api_template.Entities;
using core_api_template.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace core_api_template.Controllers;

/// <summary>
/// Exception Tests
/// </summary>
[ApiController]
[Route("[controller]")]
public class ExceptionTestController : ControllerBase
{

    private readonly ILogger<ExceptionTestController> _logger;

    public ExceptionTestController(ILogger<ExceptionTestController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Valid number will return exception with safe exception message while invalid number will only log exception
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="AppException"></exception>
    /// <exception cref="Exception"></exception>
    [HttpGet(Name = "GetUnhandledException{number}")]
    public IEnumerable<WeatherForecast> Get(string number)
    {
        if (int.TryParse(number, out _))
        {
            throw new AppException("You entered a number but it was a tick! I threw an exception any way! At lease this is safe!");
        }

        throw new Exception("Unhandled application exception with sensitive data!");
    }
}

