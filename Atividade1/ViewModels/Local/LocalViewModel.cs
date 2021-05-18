using System;
using System.Collections.Generic;

namespace Atividade1.ViewModels.Local
{
    public class LocalViewModel
    {
        public string MsgSucess { get; set; }
        
        public string MsgFail { get; set; }
        
        public ICollection<Local> Locais { get; set; }


        public LocalViewModel()
        {
            Locais = new List<Local>();
        }
    }

    public class Local
    {
        public Guid Id { get; set; }
        
        public string Nome { get; set; }

        public string Cidade { get; set; }
        
        public string Bairro { get; set; }
        
        public string Capacidade { get; set; }

    }

}