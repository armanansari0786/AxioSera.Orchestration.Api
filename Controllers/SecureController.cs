using Microsoft.AspNetCore.Mvc;

namespace AxioSera.Orchestration.Api.Controllers
{
    public class SecureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
