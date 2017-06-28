using Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class UsuarioConfig
    {
        public void DefinirConfiguracoesDaEntidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .ToTable("AspNetUsers");
        }
    }
}