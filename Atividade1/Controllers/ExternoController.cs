using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    public class ExternoController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }
        
        public IActionResult Cadastro()
        {
            return View();
        }
        
        public IActionResult RecuperarConta()
        {
            return View();
        }
        
        public IActionResult TermosUso()
        {
            return View();
        }
        
        public IActionResult PoliticaPrivacidade()
        {
            return View();
        }
        
    }
}