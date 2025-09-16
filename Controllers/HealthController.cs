using Microsoft.AspNetCore.Mvc;

namespace AxioSera.Orchestration.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult Health() => Ok(new { status = "Healthy" });
    }
}
