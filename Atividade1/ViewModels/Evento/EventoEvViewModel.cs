using System;
using System.Collections.Generic;

namespace Atividade1.ViewModels.Evento
{
    public class EventoEvViewModel
    {
        public EvEdit Ee { get; set; }
    }

    public class EvEdit
    {
        public Guid Id { get; set; }
        
        public string Descricao { get; set; }
        
        public string TipoEvento { get; set; }
        
        public string SituacaoEvento { get; set; }
        
        public string Observacao { get; set; }
        
        public string DataHoraInicio { get; set; }
        
        public string DataHoraTermino { get; set; }

    }

}