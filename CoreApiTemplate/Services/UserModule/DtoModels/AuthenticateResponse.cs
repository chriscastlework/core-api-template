using core_api_template.Services.UserModule.Entity;

namespace core_api_template.Services.UserModule.DtoModels;

public class AuthenticateResponse
{
    public AuthenticateResponse()
    {

    }

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Token { get; set; }


    public AuthenticateResponse(User user, string? token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Token = token;
    }
}