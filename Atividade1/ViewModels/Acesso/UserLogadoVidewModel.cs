using System;

namespace Atividade1.ViewModels.Acesso
{
    public class UserLogadoVidewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataNasciemnto { get; set; }
        
    }
}