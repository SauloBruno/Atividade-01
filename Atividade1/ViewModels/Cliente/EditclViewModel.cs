using System;
using Atividade1.Models.Cliente;

namespace Atividade1.ViewModels.Cliente
{
    public class EditclViewModel
    {
        public Guid Id { get; set; }

        public Cli Cliente { get; set; }
    }

    public class Cli
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Data { get; set; }
        public string Endereco { get; set; }
        public string Descricao { get; set; }
        public string obs { get; set; }
    }
}