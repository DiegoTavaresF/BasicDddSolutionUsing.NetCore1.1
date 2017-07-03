using System;

namespace Domain.Entities.ExamplesEntity
{
    public interface IExampleEntity
    {
        Guid Id { get; }
        string Name { get; }
    }
}