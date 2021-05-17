using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Atividade1.Models.Acesso;
using Atividade1.Models.Cliente;
using Atividade1.RequestModel;
using Atividade1.ViewModels.Acesso;
using Atividade1.ViewModels.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Atividade1.Controllers
{
    public class InternoController : Controller
    {
        private readonly AcessoService _acessoService;
        private readonly ClienteService _clienteService;

        public InternoController(AcessoService acessoService, ClienteService clienteService)
        {
            _acessoService = acessoService;
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PainelUsuario(string id)
        {
            if (id != null)
            {
                var u = _acessoService.BuscarPeloLogin(id);

                Console.WriteLine("Email: "+id);
            
                var viewModel = new UserLogadoVidewModel();
                viewModel.Id = u.Id;
                viewModel.Email = u.UserName;
                viewModel.Senha = u.PasswordHash;
                viewModel.DataNasciemnto = u.Data;

                return View(viewModel);
            }

            return View();   
            
        }
        
        public async Task<IActionResult> Editar(UserEditRequestModel ud)
        {
            var id = ud.Id;
            var email = ud.Email;

            try
            {
                await _acessoService.EditarUsuario(id, email);

                TempData["msg-editar"] = "Usuario editado com sucesso.";

                return RedirectToAction("Login","Externo");
            }
            catch (CadastroException exception)
            {
                var listaErros = new List<string>();
                
                foreach (var e in exception.Erros)
                {
                    listaErros.Add(e.Description);
                }
                
                TempData["msg-erros-editar"] = listaErros;

                return RedirectToAction("PainelUsuario");
            }
            
        }
        public IActionResult Ajuda()
        {
            return View();
        }
        
        public IActionResult Sessao()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult SessaoCliente()
        {
            var viewModel = new ClienteViewModel();

            viewModel.MsgSucess = (string) TempData["cad-cliente"];

            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult SessaoCliente(ClienteCadRequestModel rm)
        {

            var nome = rm.Nome;
            var email = rm.Email;
            var cpf = rm.CPF;
            var data = rm.Data;
            var tipo = rm.tipoCliente;
            var endereco = rm.Endereco;
            var descricao = rm.Descricao;
            var observacao = rm.Observacao;

            _clienteService.InserirCliente(nome, email, cpf, data, tipo, endereco, descricao, observacao);

            TempData["cad-cliente"] = "Cliente cadastrado com sucesso"; 
        
            return RedirectToAction("SessaoCliente");

        }

    }
}