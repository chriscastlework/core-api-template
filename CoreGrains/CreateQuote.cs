using CoreGrainInterfaces;
using Serilog;

namespace CoreGrains;

public class CreateQuote : Orleans.Grain, ICreateQuote
{
    private readonly ILogger _logger;

    public CreateQuote(ILogger logger)
    {
        this._logger = logger;
    }

    Task<string> ICreateQuote.SayHello(string greeting)
    {
        _logger.Information("Hello World!", greeting);
        return Task.FromResult("Hello World!");
    }
}