using Domain.Entities.ExamplesEntity;
using Domain.Entities.Usuario;
using Infra.BaseIdentity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Contexts
{
    public interface IContextBase : IApplicationDbContext
    {
        DbSet<ExampleEntity> ExamplesEntity { get; set; }
        DbSet<Usuario> Usuarios { get; set; }

        int SaveChanges();
    }
}