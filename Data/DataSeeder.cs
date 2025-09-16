using AxioSera.Orchestration.Api.Models;

namespace AxioSera.Orchestration.Api.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (!db.Roles.Any())
            {
                db.Roles.Add(new Role { Name = "Admin" });
                db.Roles.Add(new Role { Name = "User" });
            }

            if (!db.Users.Any())
            {
                db.Users.Add(new User { Username = "admin", Password = "Admin@123", RoleName = "Admin" });
            }

            if (!db.Categories.Any())
            {
                db.Categories.AddRange(new[] {
                    new Category { Name = "General", Description = "General category" },
                    new Category { Name = "Billing", Description = "Billing-related" }
                });
            }

            db.SaveChanges();
        }
    }
}
