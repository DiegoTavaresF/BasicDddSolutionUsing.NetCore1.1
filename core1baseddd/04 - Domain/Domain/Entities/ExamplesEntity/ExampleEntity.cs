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

        public string Name { get; private set; }

        public void SetName(string _name)
        {
            if (string.IsNullOrWhiteSpace(_name) || _name.Length < PropertyLength.ExampleEntity_Name_MinLength)
            {
                AddError(string.Format("Name must be longer than {0} characters", PropertyLength.ExampleEntity_Name_MinLength));
                return;
            }

            if (_name.Length > PropertyLength.ExampleEntity_Name_MaxLength)
            {
                AddError(string.Format("Name must be less than {0} characters", PropertyLength.ExampleEntity_Name_MaxLength));
                return;
            }

            Name = _name;
        }
    }
}