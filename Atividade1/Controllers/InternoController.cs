using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    public class InternoController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PainelUsuario()
        {
            return View();
        }
        
        public IActionResult Ajuda()
        {
            return View();
        }
        
    }
}