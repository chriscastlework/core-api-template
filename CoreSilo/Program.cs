using CoreGrains;
using CoreServices.WeatherForecastModule;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

// add serilog 
CoreApiAbstractions.ProgramExtensions.Serilog.SetUpSerilog(builder);

builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering().Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "CoreSilo";
        })
        //.AddMemoryGrainStorageAsDefault();
        .UseLocalhostClustering();
    siloBuilder.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(CreateQuote).Assembly).WithReferences());
    siloBuilder.UseDashboard(options => { });
});

var app = builder.Build();

app.Run();