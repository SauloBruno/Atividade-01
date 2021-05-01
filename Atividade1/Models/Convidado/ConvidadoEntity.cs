using System;
using Atividade1.Models.Evento;
using Atividade1.Models.Situacao;

namespace Atividade1.Models.Convidado
{
    public class ConvidadoEntity
    {
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Cpf { get; set; }
        
        public DateTime DataDeNascimento { get; set; }
        
        public EventoEntity Evento { get; set; }
        
        public SituacaoConvidadoEntity Situacao { get; set; }
        
        public string TextoObservacao { get; set; }
        
        public DateTime DataInsercao { get; set; }
        
        public DateTime DataUltimaModificacao { get; set; }

    }
}