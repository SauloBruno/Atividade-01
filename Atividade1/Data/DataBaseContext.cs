using System;
using Atividade1.Models.Acesso;
using Atividade1.Models.Cliente;
using Atividade1.Models.Evento;
using Atividade1.Models.Local;
using Atividade1.Models.Situacao;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Atividade1.Data
{
    public class DataBaseContext : IdentityDbContext<Usuario, Papel, Guid>
    {

        public DbSet<ClienteEntity> Cliente { get; set; } 
        public DbSet<EventoEntity> Evento { get; set; }
        public DbSet<TipoClienteEntity> TipoCliente { get; set; }
        public DbSet<LocalEntity> Local { get; set; }
        public DbSet<TipoEventoEntity> TipoEvento { get; set; }
        public DbSet<SituacaoConvidadoEntity> SituacaoConvidado { get; set; }
        public DbSet<SituacaoEventoEntity> SituacaoEvento { get; set; }
    
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
    }
}