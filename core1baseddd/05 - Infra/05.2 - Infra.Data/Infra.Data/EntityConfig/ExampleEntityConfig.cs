using Domain.Entities.ExamplesEntity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class ExampleEntityConfig
    {
        public void DefinirConfiguracoesDaEntidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExampleEntity>(e =>
            {
                e.ToTable("ExampleEntity");

                e.HasKey(w => w.Id);
            });
        }
    }
}