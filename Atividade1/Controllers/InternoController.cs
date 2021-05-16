using System;
using System.Linq;
using System.Reflection.Metadata;
using Atividade1.Models.Acesso;
using Atividade1.RequestModel;
using Atividade1.ViewModels.Acesso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Atividade1.Controllers
{
    public class InternoController : Controller
    {
        private readonly AcessoService _acessoService;

        public InternoController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PainelUsuario(string id)
        {
            var u = _acessoService.BuscarPeloLogin(id);

            Console.WriteLine("Email: "+id);
            
            var viewModel = new UserLogadoVidewModel();
            viewModel.Id = u.Id;
            viewModel.Email = u.Email;
            viewModel.Senha = u.PasswordHash;
            viewModel.DataNasciemnto = u.Data;
            
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Editar(UserEditRequestModel ud)
        {
            var id = ud.Id;
            var email = ud.Email;
            var senha = ud.Senha;

            

            return View("Ajuda");
        }
        
        public IActionResult Ajuda()
        {
            return View();
        }
        
        public IActionResult Sessao()
        {
            return View();
        }
        
    }
}