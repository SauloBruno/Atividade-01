using System;
using Atividade1.Models.Cliente;
using Atividade1.Models.Local;
using Atividade1.Models.Situacao;

namespace Atividade1.Models.Evento
{
    public class EventoEntity
    {
        public Guid Id { get; set; }
        
        public string Descricao { get; set; }//v
        
        public TipoEventoEntity TipoEvento { get; set; }//v

        public DateTime DataHoraInicio { get; set; }//v

        public DateTime DataHoraTermino { get; set; }//v

        public ClienteEntity Cliente { get; set; }//v

        public SituacaoEventoEntity Situacao { get; set; }//v

        public LocalEntity Local { get; set; }//fazer

        public string TextoObservacao { get; set; }//v

        public DateTime DataInsercao { get; set; }

        public DateTime DataUltimaModificacao { get; set; }
        public EventoEntity()
        {
            Id = new Guid();
        }
    }
}