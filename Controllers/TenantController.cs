using Microsoft.AspNetCore.Mvc;
using AxioSera.Orchestration.Api.Data;
using AxioSera.Orchestration.Api.Models;

namespace AxioSera.Orchestration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TenantController(AppDbContext db) { _db = db; }

        [HttpPost("domain")]
        public IActionResult AddDomain([FromBody] Tenant dto)
        {
            var t = new Tenant { Domain = dto.Domain };
            _db.Tenants.Add(t);
            _db.SaveChanges();
            return Ok(t);
        }
    }
}
