using System;
using System.Collections.Generic;
using System.Linq;
using Atividade1.Data;
using Microsoft.EntityFrameworkCore;

namespace Atividade1.Models.Cliente
{
    public class ClienteService
    {
        private readonly DataBaseContext _dataBaseContext;

        public ClienteService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<ClienteEntity> ObterClientes()
        {
            return _dataBaseContext.Cliente
                .Include(c => c.Eventos)
                .Include(c => c.TipoCliente)
                .ToList();
        }

        public ClienteEntity BuscarPeloLogin(string email)
        {
            try
            {
                return _dataBaseContext.Cliente.Single(c => c.Email.Equals(email));
            }
            catch (Exception e)
            {
                ClienteEntity cl = new ClienteEntity();
                cl.Nome = "vazio";
                return cl;
            }
            
        }

        public void InserirCliente(string nome, string email, string cpf, string data, string tipo, string endereco, string descricao, string observacao)
        {
            
            TipoClienteEntity tc = new TipoClienteEntity();
            tc.Tipo = tipo;
            _dataBaseContext.TipoCliente.Add(tc);

            ClienteEntity c = new ClienteEntity();
            c.Nome = nome;
            c.Email = email;
            c.Cpf = cpf;
            c.DataDeNascimento = DateTime.Parse(data);
            c.TipoCliente = tc;
            c.Endereco = endereco;
            c.Descricao = descricao;
            c.TextoObservacao = observacao;
            
            if (tipo.Equals("Juridica"))
            {
                var cnpj = Guid.NewGuid();
                c.Cnpj = cnpj;
            }
            else
            {
                var cnpj = Guid.Empty;
                c.Cnpj = cnpj;
            }

            c.DataInsercao = DateTime.Now;
            c.DataUltimaModificacao = DateTime.Now;

            _dataBaseContext.Cliente.Add(c);
            _dataBaseContext.SaveChanges();
        }

        public void Remover(Guid id)
        {
            var c = _dataBaseContext.Cliente.Find(id);
            _dataBaseContext.Cliente.Remove(c);
            _dataBaseContext.SaveChanges();
        }
    }
}