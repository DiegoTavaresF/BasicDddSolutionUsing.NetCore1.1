using Application.Services.ExamplesEntity.Dto;
using Domain.Entities;
using FluentValidation;

namespace Application.Services.ExamplesEntity.Validator
{
    public class ExampleEntityValidator : AbstractValidator<ExampleEntitySaveEditDto>
    {
        public ExampleEntityValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                    .WithMessage(string.Format("Name must be between {0} and {1} characters.", PropertyLength.ExampleEntity_Name_MinLength, PropertyLength.ExampleEntity_Name_MaxLength))
                .Length(PropertyLength.ExampleEntity_Name_MinLength, PropertyLength.ExampleEntity_Name_MaxLength)
                    .WithMessage(string.Format("Name must be between {0} and {1} characters.", PropertyLength.ExampleEntity_Name_MinLength, PropertyLength.ExampleEntity_Name_MaxLength));
        }
    }
}