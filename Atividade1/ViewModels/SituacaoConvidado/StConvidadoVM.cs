using System.Collections.Generic;
using Atividade1.Models.Evento;
using Atividade1.Models.Situacao;

namespace Atividade1.ViewModels.SituacaoConvidado
{
    public class StConvidadoVM
    {
        public string MsgSucess { get; set; }
        public string MsgFail { get; set; }

        public ICollection<SituacaoConvidadoEntity> Lista { get; set; }

        public StConvidadoVM()
        {
            Lista = new List<SituacaoConvidadoEntity>();
        }
    }
}