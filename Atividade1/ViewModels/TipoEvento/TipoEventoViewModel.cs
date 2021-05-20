using System.Collections.Generic;
using Atividade1.Models.Evento;

namespace Atividade1.ViewModels.TipoEvento
{
    public class TipoEventoViewModel
    {
        public string MsgSucess { get; set; }
        public string MsgFail { get; set; }

        public ICollection<TipoEventoEntity> ListaTe { get; set; }

        public TipoEventoViewModel()
        {
            ListaTe = new List<TipoEventoEntity>();
        }
    }
}