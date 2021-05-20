using System.Collections.Generic;
using Atividade1.Models.Situacao;

namespace Atividade1.ViewModels.SituacaoEvento
{
    public class StEventoVM
    {
        public string MsgSucess { get; set; }
        public string MsgFail { get; set; }

        public ICollection<SituacaoEventoEntity> Lista { get; set; }

        public StEventoVM()
        {
            Lista = new List<SituacaoEventoEntity>();
        }        
    }
}