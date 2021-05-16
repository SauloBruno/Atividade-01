using System;

namespace Atividade1.Models.Situacao
{
    public class SituacaoEventoEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public SituacaoEventoEntity()
        {
            Id = new Guid();
        }
    }
}