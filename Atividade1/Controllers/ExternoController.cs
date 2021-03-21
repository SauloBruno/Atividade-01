using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    public class ExternoController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}