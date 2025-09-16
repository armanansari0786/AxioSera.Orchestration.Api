using AxioSera.Orchestration.Api.Models;

namespace AxioSera.Orchestration.Api.Services
{
    public interface IAuthService
    {
        User CreateUser(string username, string password, string role);
        User ValidateUser(string username, string password);
    }
}
