using System;

namespace Atividade1.RequestModel
{
    public class UserEditRequestModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}