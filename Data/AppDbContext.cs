using Microsoft.EntityFrameworkCore;
using AxioSera.Orchestration.Api.Models;

namespace AxioSera.Orchestration.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<WorkflowSimulation> WorkflowSimulations { get; set; }
    }
}
