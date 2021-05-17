using System;
using System.Collections.Generic;
using Atividade1.Models.Evento;

namespace Atividade1.Models.Cliente
{
    public class ClienteEntity
    {
        public Guid Id { get; set; }
        
        public string Descricao { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }//não inserido
        
        public TipoClienteEntity TipoCliente { get; set; }//definido no formulario

        public string Cpf { get; set; }//depende do tipoCliente

        public DateTime DataDeNascimento { get; set; }

        public Guid Cnpj { get; set; }//baseado no tipo do cliente

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public string TextoObservacao { get; set; }

        public DateTime DataInsercao { get; set; }//durante a inserção

        public DateTime DataUltimaModificacao { get; set; }//durabte a inserçaõ

        public ClienteEntity()
        {
            Id = new Guid();
            Eventos = new List<EventoEntity>();
        }
        
    }
}