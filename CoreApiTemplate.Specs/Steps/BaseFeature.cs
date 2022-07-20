using CoreApiAbstractions.Orleans;
using CoreGrainInterfaces;
using CoreServices.WeatherForecastModule;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework.Internal;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.TestingHost;
using ILogger = Serilog.ILogger;

namespace CoreApiTemplate.Specs.Steps;

public abstract class BaseFeature
{

    protected BaseFeature(ScenarioContext scenarioContext)
    {
        // var builder = new TestClusterBuilder();
        // builder.AddSiloBuilderConfigurator<TestSiloConfigurations>();
        // var cluster = builder.Build();
        // cluster.Deploy();
        //
        // // working
        // var hello = cluster.GrainFactory.GetGrain<ICreateQuote>(Guid.NewGuid());
        // var greeting = hello.SayHello("test").Result;
        // var weatherGrain = cluster.GrainFactory.GetGrain<IGetWeatherForecast>(Guid.NewGuid());
        // var weatherGrainResult = weatherGrain.SayHello("test").Result;
        
        ScenarioContext = scenarioContext;
        var webAppFactory = new WebApplicationFactory<Program>();
        Client = webAppFactory.CreateDefaultClient();
    }
    
    protected readonly ScenarioContext ScenarioContext;
    protected readonly HttpClient Client;
    protected string Result = "";
    
}
// public class TestSiloConfigurations : ISiloConfigurator {
//     public void Configure(ISiloBuilder siloBuilder)
//     {
//         siloBuilder.ConfigureServices(c =>  c
//             .AddSingleton<IWeatherForecastService, WeatherForecastService>()
//             .AddSingleton<ILogger, ILogger>(mockLogger => new Mock<ILogger>().Object))
//             .UseLocalhostClustering().Configure<ClusterOptions>(options =>
//         {
//             options.ClusterId = "dev";
//             options.ServiceId = "CoreSilo";
//         });
//     }
// }