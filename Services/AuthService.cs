using AxioSera.Orchestration.Api.Models;
using AxioSera.Orchestration.Api.Data;

namespace AxioSera.Orchestration.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        public AuthService(AppDbContext db) { _db = db; }

        public User CreateUser(string username, string password, string role)
        {
            var u = new User { Username = username, Password = password, RoleName = role };
            _db.Users.Add(u);
            _db.SaveChanges();
            return u;
        }

        public User ValidateUser(string username, string password)
        {
            return _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
