using System;

namespace AxioSera.Orchestration.Api.Models
{
    public class WorkflowSimulation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RequestJson { get; set; }
        public string ResponseJson { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
