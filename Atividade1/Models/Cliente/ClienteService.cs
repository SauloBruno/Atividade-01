using System;
using System.Diagnostics.CodeAnalysis;
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

        public void InserirCliente(string nome, string email, string cpf, string data, string tipo, string endereco, string descricao, string observacao, Guid cnpj)
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
                c.Cnpj = cnpj;
                c.DataInsercao = DateTime.Now;
                c.DataUltimaModificacao = DateTime.Now;

                _dataBaseContext.Cliente.Add(c);
                _dataBaseContext.SaveChanges();
        }
    }
}