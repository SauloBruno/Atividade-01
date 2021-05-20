using System;
using System.Collections.Generic;

namespace Atividade1.ViewModels.Evento
{
    public class EventoViewModel
    {
        public string MsgSucess { get; set; }
        
        public string MsgFail { get; set; }
        
        public List<Clt> Clientes { get; set; }

        public List<Event> Eventos { get; set; }
        public EventoViewModel()
        {
            Clientes = new List<Clt>();
            Eventos = new List<Event>();
        }
    }

    public class Event
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string TipoEvento { get; set; }
        public string SituacaoEvento { get; set; }
        public string Observacao { get; set; }
        public string DataHoraInicio { get; set; }
        public string DataHoraTermino { get; set; }
        public string DataInsercao { get; set; }
        public string DataAlteracao { get; set; }
        
    }

    public class Clt
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        
    }
}