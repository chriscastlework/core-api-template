using CoreServices.WeatherForecastModule.Entity;
using NUnit.Framework;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CoreApiTemplate.Specs.Steps;

[Binding]
public sealed class WeatherForecastStepDefinitions : BaseFeature
{
    public WeatherForecastStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
    }

    [When(@"weather api is called")]
    public void WhenWeatherApiIsCalled()
    {
        var response = Client.GetAsync("/WeatherForecast").Result;
        Result = response.Content.ReadAsStringAsync().Result;
    }

    [Then(@"the result should have weather information")]
    public void ThenTheResultShouldHaveWeatherInformation()
    {
        var serializedResult = JsonSerializer.Deserialize<WeatherForecast[]>(Result);
        Assert.NotNull(serializedResult);
    }
}