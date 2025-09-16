using System;

namespace AxioSera.Orchestration.Api.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
