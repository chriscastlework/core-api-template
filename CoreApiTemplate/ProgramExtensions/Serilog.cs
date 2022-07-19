using Serilog;

namespace core_api_template.ProgramExtensions;

public static class Serilog
{
    public static void SetUpSerilog(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Logging.ClearProviders();
        webApplicationBuilder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .ReadFrom.Configuration(ctx.Configuration));
    }
}