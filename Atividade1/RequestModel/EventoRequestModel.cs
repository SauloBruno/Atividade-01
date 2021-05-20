using System;

namespace Atividade1.RequestModel
{
    public class EventoRequestModel
    {
        public Guid param { get; set; }
        public Guid Cliente { get; set; }

        public string Descricao { get; set; }
        
        public string TipoEvento { get; set; }
        
        public string SituacaoEvento { get; set; }
        
        public string Observacao { get; set; }
        public string DataHinicio { get; set; }
        
        public string DataHtermino { get; set; }

        //Atributos local
        public string Nome { get; set; }
        
        public string Cidade { get; set; }
        
        public string Bairro { get; set; }
        
        public string Capacidade { get; set; }
    }
}