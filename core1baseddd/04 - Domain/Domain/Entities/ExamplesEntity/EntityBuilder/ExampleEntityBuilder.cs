using System;

namespace Domain.Entities.ExamplesEntity.EntityBuilder
{
    public class ExampleEntityBuilder
    {
        private string Name { get; set; }

        public ExampleEntity Build()
        {
            var result = new ExampleEntity();
            result.SetName(Name);
            result.SetId(Guid.NewGuid());

            return result;
        }

        public ExampleEntityBuilder WithName(string _name)
        {
            Name = _name;
            return this;
        }
    }
}