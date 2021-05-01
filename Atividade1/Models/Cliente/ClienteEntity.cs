using System;

namespace Atividade1.Models.Cliente
{
    public class ClienteEntity
    {
        public int Id { get; set; }
        
        public string Descricao { get; set; }
        
        public TipoClienteEntity TipoCliente { get; set; }

        public string Cpf { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Cnpj { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public string TextoObservacao { get; set; }

        public DateTime DataInsercao { get; set; }

        public DateTime DataUltimaModificacao { get; set; }
        
        public ClienteEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        
    }
}