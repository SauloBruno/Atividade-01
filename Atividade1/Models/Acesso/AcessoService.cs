using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atividade1.Models.Acesso
{
    public class AcessoService
    {
        private readonly UserManager<Usuario> _user;
        private readonly SignInManager<Usuario> _sign;

        public AcessoService(
            UserManager<Usuario> user,
            SignInManager<Usuario> sign
        ){
            _user = user;
            _sign = sign;
        }

        public async Task AutenticarUsuario(string email, string senha)
        {
            var resultado = await _sign.PasswordSignInAsync(email, senha, false, false);
            
            if (!resultado.Succeeded)
            {
                throw new Exception("Campo Email ou Senha incorretos!");
            }
        }

        public async Task RegistrarUser(string nome, string email, string data, string senha)
        {
            var usuario = new Usuario()
            {
                UserName = email,
                Email = email,
                Data = DateTime.Parse(data)
            };

            var resultado = await _user.CreateAsync(usuario, senha);
            
            if (!resultado.Succeeded)
            {
                throw new CadastroException(resultado.Errors);

            }
            
        }

    }
}