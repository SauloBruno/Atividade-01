using System;
using Microsoft.AspNetCore.Identity;

namespace Atividade1.Models.Acesso
{
    public class Usuario : IdentityUser<Guid>
    {
        public DateTime Data { get; set; }
    }
}