using System;
using Atividade1.Data;

namespace Atividade1.Models.Cliente
{
    public class ClienteService
    {
        private readonly DataBaseContext _dataBaseContext;

        public ClienteService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
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

            var cnpj = Guid.Empty;
            if (tipo.Equals("Juridica"))
            {
                cnpj = new Guid();
            }

            c.Cnpj = cnpj;
            c.DataInsercao = DateTime.Now;
            c.DataUltimaModificacao = DateTime.Now;

            _dataBaseContext.Cliente.Add(c);
            _dataBaseContext.SaveChanges();
        }
    }
}