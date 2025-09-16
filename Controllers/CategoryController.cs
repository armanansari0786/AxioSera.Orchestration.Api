using Microsoft.AspNetCore.Mvc;
using AxioSera.Orchestration.Api.Data;

namespace AxioSera.Orchestration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db) { _db = db; }

        [HttpGet("getallcategories")]
        public IActionResult GetAllCategories() => Ok(_db.Categories.ToList());
    }
}
