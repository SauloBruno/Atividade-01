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
using Microsoft.VisualBasic;

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
            var p1 = (string)TempData["busca"];
            var p2 = (string)TempData["nome"];
            var p3 = (string)TempData["tipo"];
            
            var viewModel = new ClienteViewModel();

            viewModel.MsgSucess = (string) TempData["cad-cliente"];
            viewModel.MsgFail = (string) TempData["cad-cliente-error"];

            List<ClienteEntity> cl = null;
            if (p1 != null)
            {
                cl = _clienteService.BuscarFiltro(p2, p3);
            }
            else
            {
                cl = _clienteService.ObterClientes();
            }

            foreach (var c in cl)
            {
                viewModel.Clientes.Add(new Cliente()
                {
                    TipoCliente = c.TipoCliente.Tipo,
                    Id = c.Id,
                    Nome = c.Nome,
                    Email = c.Email,
                    Cpf = c.Cpf,
                    DataNascimento = c.DataDeNascimento.ToString("dd-MM-yyyy"),
                    DataInsercao = c.DataInsercao.ToString("dd-MM-yyyy"),
                    DataUltimaAlteracao = c.DataUltimaModificacao.ToString("dd-MM-yyyy")
                });
            }
            
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

            if (nome == null)
            {
                TempData["cad-cliente-error"] = "Campo Nome deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (email == null)
            {
                TempData["cad-cliente-error"] = "Campo Email deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (cpf == null || cpf.Length < 11 )
            {
                TempData["cad-cliente-error"] = "Campo CPF deve ser preenchido e deve possuir 11 digitos!";
                return RedirectToAction("SessaoCliente");
            }
            else
            {
                cpf = cpf.Replace(".", "").Replace("-", "");
                Console.WriteLine(cpf);
            }

            if (tipo.Equals("vazio"))
            {
                TempData["cad-cliente-error"] = "Campo Tipo cliente deve ser selecionado!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (endereco == null)
            {
                TempData["cad-cliente-error"] = "Campo Endereço deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (data == null)
            {
                TempData["cad-cliente-error"] = "Campo Data deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (descricao == null)
            {
                TempData["cad-cliente-error"] = "Campo Descrição deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (observacao == null)
            {
                TempData["cad-cliente-error"] = "Campo Observação deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            var cl = _clienteService.BuscarPeloLogin(email);

            if (cl.Nome != "vazio")
            {
                TempData["cad-cliente-error"] = "Login já existe!";
                return RedirectToAction("SessaoCliente");
            }

            _clienteService.InserirCliente(nome, email, cpf, data, tipo, endereco, descricao, observacao);

            TempData["cad-cliente"] = "Cliente cadastrado com sucesso"; 
        
            return RedirectToAction("SessaoCliente");

        }
        
        [HttpGet]
        public IActionResult SessaoLocal()
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult SessaoLocal(LocalRequestModel rm)
        {
            
            
            
            return RedirectToAction("SessaoCliente");
        }
            
        [HttpPost]
        public IActionResult SessaoClienteBusca(ClienteCadRequestModel rm)
        {
            
            var nome = rm.Nome;
            var tipo = rm.tipoCliente;
            
            TempData["busca"] = "buscar";
            TempData["nome"] = nome;
            TempData["tipo"] = tipo;
            
            return RedirectToAction("SessaoCliente");

        }
            
        [HttpGet]
        public IActionResult EditarCl(Guid id)
        {
            var c = _clienteService.BuscarPeloId(id);
            
            var viewModel = new EditclViewModel();
            viewModel.Id = id;
            
            viewModel.Cliente = new Cli()
            {
                Nome = c.Nome,
                Email = c.Email,
                Cpf = c.Cpf,
                Data = c.DataDeNascimento.ToString("dd/MM/yyyy"),
                Endereco = c.Endereco,
                Descricao = c.Descricao,
                obs = c.TextoObservacao
            };
            
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult EditarCl(ClienteCadRequestModel rm)
        {
            var ac = rm.ac;
            var nome = rm.Nome;
            var email = rm.Email;
            var cpf = rm.CPF;
            var data = rm.Data;
            var endereco = rm.Endereco;
            var descricao = rm.Descricao;
            var observacao = rm.Observacao;

            if (nome == null)
            {
                TempData["cad-cliente-error"] = "Campo Nome deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (email == null)
            {
                TempData["cad-cliente-error"] = "Campo Email deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (cpf == null || cpf.Length < 11 )
            {
                TempData["cad-cliente-error"] = "Campo CPF deve ser preenchido e deve possuir 11 digitos!";
                return RedirectToAction("SessaoCliente");
            }
            else
            {
                cpf = cpf.Replace(".", "").Replace("-", "");
                Console.WriteLine(cpf);
            }

            if (endereco == null)
            {
                TempData["cad-cliente-error"] = "Campo Endereço deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (data == null)
            {
                TempData["cad-cliente-error"] = "Campo Data deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (descricao == null)
            {
                TempData["cad-cliente-error"] = "Campo Descrição deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            if (observacao == null)
            {
                TempData["cad-cliente-error"] = "Campo Observação deve ser preenchido!";
                return RedirectToAction("SessaoCliente");
            }
            
            var cl = _clienteService.BuscarPeloLogin(email);

            if (cl.Nome != "vazio" && cl.Id.ToString() != ac.ToString())
            {
                TempData["cad-cliente-error"] = "Login já existe!";
                return RedirectToAction("SessaoCliente");
            }

            _clienteService.EditarCliente(ac, nome, email, cpf, data, endereco, descricao, observacao);

            TempData["cad-cliente"] = "Cliente Editado com sucesso"; 
        
            return RedirectToAction("SessaoCliente");

        }
            
        public IActionResult Excluir(Guid id)
        {
            _clienteService.Remover(id);
            
            return RedirectToAction("SessaoCliente");
        }

    }
}