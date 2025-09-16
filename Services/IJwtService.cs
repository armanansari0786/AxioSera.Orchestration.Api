using AxioSera.Orchestration.Api.Models;

namespace AxioSera.Orchestration.Api.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
