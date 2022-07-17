using core_api_template.Entities;
using core_api_template.Models;

namespace core_api_template.Services;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
}