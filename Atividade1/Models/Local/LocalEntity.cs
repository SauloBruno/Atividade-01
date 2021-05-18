using System;

namespace Atividade1.Models.Local
{
    public class LocalEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int Capacidade { get; set; }

        public LocalEntity()
        {
            Id = new Guid();
        }
    }
}