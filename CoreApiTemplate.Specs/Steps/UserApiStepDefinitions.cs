using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using core_api_template.Entities;
using core_api_template.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CoreApiTemplate.Specs.Steps;

[Binding]
public sealed class UserApiStepDefinitions : BaseFeature
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef



    public UserApiStepDefinitions(ScenarioContext scenarioContext): base(scenarioContext)
    {
    }

    [When(@"the user api is called")]
    public void WhenTheUserApiIsCalled()
    {
        var response = Client.GetAsync("/Users").Result;
        Result = response.Content.ReadAsStringAsync().Result;
    }

    [Then(@"the result is unauthorised")]
    public void ThenTheResultIsUnauthorised()
    {
        Assert.IsTrue(Result.Contains("Unauthorized"));
    }
    
    [Given(@"user is authenticated")]
    public void GivenUserIsAuthenticated()
    {
        HttpContent content = new StringContent(JsonConvert.SerializeObject(new
        {
            username = "test",
            password = "test"
        
        }));
        content.Headers.Clear();
        content.Headers.Add("Content-Type", "application/json"); 
        var responsePost = Client.PostAsync("/Users/authenticate", content).Result;
          
        var stringResultPost = responsePost.Content.ReadAsStringAsync().Result;
        
        var serializedResult = JsonSerializer.Deserialize<AuthenticateResponse>(stringResultPost, new JsonSerializerOptions 
        {
            PropertyNameCaseInsensitive = true
        });

        Debug.Assert(serializedResult != null, nameof(serializedResult) + " != null");
        Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", serializedResult.Token);
    }

    [Then(@"the result has user data")]
    public void ThenTheResultHasUserData()
    {
        var serializedResult = JsonSerializer.Deserialize<User[]>(Result);
        Assert.NotNull(serializedResult);
    }
}