using Microsoft.AspNetCore.Mvc;
using AxioSera.Orchestration.Api.Data;
using AxioSera.Orchestration.Api.Dtos;
using AxioSera.Orchestration.Api.Models;

namespace AxioSera.Orchestration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly AppDbContext _db;
        public WorkflowController(AppDbContext db) { _db = db; }

        [HttpPost("simulation")]
        public IActionResult RunSimulation([FromBody] RunSimulationRequestDto rq)
        {
            var sim = new WorkflowSimulation { Name = rq.Name ?? "sim", RequestJson = System.Text.Json.JsonSerializer.Serialize(rq.Payload), ResponseJson = "{ \"status\": \"ok\" }" };
            _db.WorkflowSimulations.Add(sim);
            _db.SaveChanges();
            return Ok(new RunSimulationResponseDto { SimulationId = sim.Id, Result = sim.ResponseJson });
        }

        [HttpGet("simulation-count")]
        public IActionResult SimulationCount() => Ok(new { count = _db.WorkflowSimulations.Count() });
    }
}
