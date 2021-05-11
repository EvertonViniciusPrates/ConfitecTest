using Microsoft.EntityFrameworkCore;
using Confitec.Infra.Mappers.Users;
using Confitec.Domain.Models.Users;

namespace Confitec.Infra.Contexts
{
    public class ConfitecDbContext : DbContext
    {
        public ConfitecDbContext(DbContextOptions<ConfitecDbContext> options)
                : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EcolaridadeMap());


            base.OnModelCreating(modelBuilder);
        }
        
    }
}
