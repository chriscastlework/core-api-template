using Microsoft.AspNetCore.Mvc.Testing;

namespace CoreApiTemplate.Specs.Steps;

public abstract class BaseFeature
{

    protected BaseFeature(ScenarioContext scenarioContext)
    {
        ScenarioContext = scenarioContext;
        // https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
        var webAppFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // ... Configure test services
            });

        Client = webAppFactory.CreateDefaultClient();
    }
    protected readonly ScenarioContext ScenarioContext;
    protected readonly HttpClient Client;
    protected string Result = "";
    
    
}