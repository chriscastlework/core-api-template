using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CoreApiAbstractions.ProgramExtensions;

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