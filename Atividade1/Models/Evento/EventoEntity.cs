using System;
using Atividade1.Models.Cliente;
using Atividade1.Models.Situacao;

namespace Atividade1.Models.Evento
{
    public class EventoEntity
    {
        public int Id { get; set; }
        
        public string Descricao { get; set; }
        
        public string Tipo { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraTermino { get; set; }

        public ClienteEntity Cliente { get; set; }

        public SituacaoEventoEntity Situacao { get; set; }

        public string Local { get; set; }

        public string TextoObservacao { get; set; }

        public DateTime DataInsercao { get; set; }

        public DateTime DataUltimaModificacao { get; set; }
        public EventoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}