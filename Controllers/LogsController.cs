using Microsoft.AspNetCore.Mvc;

namespace AxioSera.Orchestration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public LogsController(IWebHostEnvironment env) { _env = env; }

        [HttpGet]
        public IActionResult GetLogs()
        {
            var logsDir = Path.Combine(_env.ContentRootPath, "Logs");
            if (!Directory.Exists(logsDir)) return Ok(new string[0]);
            var files = Directory.GetFiles(logsDir).Select(Path.GetFileName).ToList();
            return Ok(files);
        }

        [HttpGet("{filename}")]
        public IActionResult GetLogFile(string filename)
        {
            var logsDir = Path.Combine(_env.ContentRootPath, "Logs");
            var file = Path.Combine(logsDir, filename);
            if (!System.IO.File.Exists(file)) return NotFound();
            var content = System.IO.File.ReadAllText(file);
            return Ok(content);
        }
    }
}
