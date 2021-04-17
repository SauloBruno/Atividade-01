using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Atividade1.Models.Acesso
{
    public class CadastroException : Exception
    {
        public IEnumerable<IdentityError> Erros { get; set; }

        public CadastroException(IEnumerable<IdentityError> erros)
        {
            Erros = erros;
        }
    }
}