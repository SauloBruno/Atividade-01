using System;
using System.Collections.Generic;
using Atividade1.Models.Evento;

namespace Atividade1.Models.Cliente
{
    public class ClienteEntity
    {
        public Guid Id { get; set; }
        
        public string Descricao { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }
        
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

        public ClienteEntity()
        {
            Id = new Guid();
            Eventos = new List<EventoEntity>();
        }
        
    }
}