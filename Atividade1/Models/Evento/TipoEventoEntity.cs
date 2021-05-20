using System;

namespace Atividade1.Models.Evento
{
    public class TipoEventoEntity
    {
        public Guid Id { get; set; }
        
        public string Tipo { get; set; }

        public TipoEventoEntity()
        {
            Id = new Guid();
        }
    }
}