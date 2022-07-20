using core_api_template.Services.UserModule;
using CoreApiAbstractions.Helpers;
using CoreApiAbstractions.Middleware;
using CoreApiAbstractions.Orleans;
using CoreApiAbstractions.ProgramExtensions;
using CoreServices.WeatherForecastModule;

var builder = WebApplication.CreateBuilder(args);

// add serilog 
CoreApiAbstractions.ProgramExtensions.Serilog.SetUpSerilog(builder);

Swagger.SetUpSwagger(builder);

// add services to DI container
var services = builder.Services;
services.AddCors();
services.AddControllers();

// configure strongly typed settings object
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// configure HTTP request pipeline
// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();