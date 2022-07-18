using core_api_template.Services.UserModule.DtoModels;
using core_api_template.Services.UserModule.Entity;

namespace core_api_template.Services.UserModule;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User?> GetAll();
    User? GetById(int id);
}