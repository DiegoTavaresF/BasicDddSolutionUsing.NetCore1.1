using Domain.Entities.ExamplesEntity;
using Domain.Entities.Usuario;
using Infra.BaseIdentity.Contexts;
using Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace Infra.Data.Contexts
{
    public class ContextBase : ApplicationDbContext, IContextBase
    {
        public ContextBase(DbContextOptions<ContextBase> options)
        {
            ConnectionString = options.FindExtension<SqlServerOptionsExtension>().ConnectionString;
        }

        public DbSet<ExampleEntity> ExamplesEntity { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        private string ConnectionString { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ExampleEntityConfig().DefinirConfiguracoesDaEntidade(modelBuilder);
            new UsuarioConfig().DefinirConfiguracoesDaEntidade(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}