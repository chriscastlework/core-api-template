using System.Diagnostics;
using CoreApiAbstractions.Orleans;
using CoreGrainInterfaces;
using Microsoft.AspNetCore.Mvc;
using CoreWebApp.Models;
using Orleans;

namespace CoreWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IClusterClient _client;

    public HomeController(ILogger<HomeController> logger, IClient client)
    {
        _logger = logger;
        _client = client.GetClient();
    }

    public async Task<IActionResult> Index()
    {
        var friend = _client.GetGrain<ICreateQuote>(Guid.NewGuid());
        var response =  await friend.SayHello("Good morning, HelloGrain!");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}