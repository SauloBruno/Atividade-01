using System;

namespace Atividade1.ViewModels.Local
{
    public class EditLcViewModel
    {
        public Guid Id { get; set; }
        public LocalEdt Local { get; set; }
    }

    public class LocalEdt
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Capacidade { get; set; }
    }

}