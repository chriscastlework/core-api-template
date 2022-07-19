using core_api_template.Helpers;
using core_api_template.Middleware;
using core_api_template.Services.UserModule;
using core_api_template.Services.WeatherForecastModule;


var builder = WebApplication.CreateBuilder(args);

// add serilog 
core_api_template.ProgramExtensions.Serilog.SetUpSerilog(builder);

// lies my swagger is still working!!
// builder.Services.AddEndpointsApiExplorer();

core_api_template.ProgramExtensions.Swagger.SetUpSwagger(builder);

// add services to DI container
var services = builder.Services;
services.AddCors();
services.AddControllers();

// configure strongly typed settings object
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
services.AddScoped<IUserService, UserService>();
services.AddScoped<IWeatherForecastService, WeatherForecastService>();

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