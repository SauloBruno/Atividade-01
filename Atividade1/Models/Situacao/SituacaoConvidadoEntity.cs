using System;

namespace Atividade1.Models.Situacao
{
    public class SituacaoConvidadoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public SituacaoConvidadoEntity()
        {
            Id = new Guid();
        }
    }
}