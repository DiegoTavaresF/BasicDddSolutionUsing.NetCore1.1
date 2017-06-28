using Domain.Base;
using System;

namespace Domain.Entities.ExamplesEntity
{
    public class ExampleEntity : Entity<Guid>, IExampleEntity
    {
        public ExampleEntity()
        {
            SetId(Guid.NewGuid());
        }

        public string Nome { get; set; }
    }
}