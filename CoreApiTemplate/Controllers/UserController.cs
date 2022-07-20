using core_api_template.Services.UserModule;
using core_api_template.Services.UserModule.DtoModels;
using CoreApiAbstractions.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace core_api_template.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response.Id == 0)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    /// <summary>
    /// Get the complete list of users
    /// </summary>
    /// <returns>List of user objects containing name </returns>
    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}