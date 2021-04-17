using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atividade1.Models.Acesso;
using Atividade1.RequestModel;
using Atividade1.ViewModels.Acesso;
using Microsoft.AspNetCore.Mvc;

namespace Atividade1.Controllers
{
    public class ExternoController : Controller
    {
        private readonly AcessoService _acessoService;

        public ExternoController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        { 
            var viewmodel = new LoginViewModel();

            viewmodel.Mensagem = (string)TempData["msg"];
            viewmodel.Erro = (string)TempData["msg-erro"];

            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(AcessoRequestModelLog requestModelLog)
        {
            var email = requestModelLog.Email;
            var senha = requestModelLog.Senha;

            if (email == null || senha == null)
            {
                TempData["msg"] = "Todos os campos devem ser preenchidos!";

                return RedirectToAction("Login");
            }

            try
            {
                await _acessoService.AutenticarUsuario(email, senha);
                
                TempData["msg-login"] = "Usuario Logado com sucesso.";
                
                //interno index
                return RedirectToActionPreserveMethod("Index","Interno");
            }
            catch (Exception e)
            {
                TempData["msg-erro"] = "Campo Login ou Senha incorretos!";
                
                return RedirectToAction("Login");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Cadastro()
        {
            var viewmodel = new CadastroViewModel();

            viewmodel.Mensagem = (string)TempData["msg"];
            viewmodel.CadErros = (string[])TempData["msg-erros-cadastro"];
            
            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Cadastro(AcessoRequestModel requestModel)
        {
            
            var nome = requestModel.Nome;
            var email = requestModel.Email;
            var dataNascimento = requestModel.Data;
            var senha = requestModel.Senha;
            
            if (email == null || nome == null || dataNascimento == null || senha == null){
                TempData["msg"] = "Todos os campos devem ser preenchidos!";

                return RedirectToAction("Cadastro");
            }

            try
            {
                await _acessoService.RegistrarUser(nome, email, dataNascimento, senha);
                
                TempData["msg-cadastro"] = "Usuario registrado com sucesso. Realize o login.";
                
                return RedirectToAction("Login");
            }
            catch (CadastroException exception)
            {
                var listaErros = new List<string>();
                
                foreach (var e in exception.Erros)
                {
                    listaErros.Add(e.Description);
                }
                
                TempData["msg-erros-cadastro"] = listaErros;

                return RedirectToAction("Cadastro");

            }            
            
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