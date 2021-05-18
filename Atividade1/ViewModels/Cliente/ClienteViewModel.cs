using System;
using System.Collections.Generic;
using Atividade1.Models.Cliente;

namespace Atividade1.ViewModels.Cliente
{
    public class ClienteViewModel
    {
        public string MsgSucess { get; set; }
        
        public string MsgFail { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public ClienteViewModel()
        {
            Clientes = new List<Cliente>();
        }
    }

    public class Cliente
    {
        public Guid Id { get; set; }
        public string TipoCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        
        public string DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string DataInsercao { get; set; }
        
        public string DataUltimaAlteracao { get; set; }
        
    }

}