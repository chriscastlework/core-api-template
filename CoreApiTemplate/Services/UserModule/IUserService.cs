using core_api_template.Entities;
using core_api_template.Services.UserModule.Entity;
using core_api_template.Services.UserModule.Models;

namespace core_api_template.Services.UserModule;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User?> GetAll();
    User? GetById(int id);
}