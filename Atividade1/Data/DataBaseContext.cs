using System;
using Atividade1.Models.Acesso;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atividade1.Data
{
    public class DataBaseContext : IdentityDbContext<Usuario, Papel, Guid>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
    }
}