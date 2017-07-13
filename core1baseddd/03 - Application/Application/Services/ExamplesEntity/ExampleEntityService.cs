using Application.Base.Dto;
using Application.Services.ExamplesEntity.Dto;
using Domain.Entities.ExamplesEntity;
using Domain.Entities.ExamplesEntity.EntityBuilder;
using FluentValidation;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.ExamplesEntity
{
    public class ExampleEntityService : IExampleEntityService
    {
        private readonly IContextBase _contextBase;
        private readonly IValidator<ExampleEntitySaveEditDto> _validatorSaveEditDto;

        public ExampleEntityService(IContextBase contextBase, IValidator<ExampleEntitySaveEditDto> validatorSaveEditDto)
        {
            _contextBase = contextBase;
            _validatorSaveEditDto = validatorSaveEditDto;
        }

        public ICollection<DropdownDto> GetDropdown()
        {
            return _contextBase.ExamplesEntity
                .AsNoTracking()
                .OrderBy(w => w.Name)
                .Select(s => new DropdownDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
        }

        public ExampleEntityGridDto GetGrid(int page = 1, string seach = null)
        {
            var result = new ExampleEntityGridDto { Search = seach };

            result.Data = _contextBase.ExamplesEntity
                                    .AsNoTracking()
                                    .Select(s => new ExampleEntityGridDataDto
                                    {
                                        Id = s.Id,
                                        Name = s.Name
                                    })
                                    .ToList();

            return result;
        }

        public ExampleEntitySaveEditDto Save(ExampleEntitySaveEditDto dto)
        {
            if (dto == null)
            {
                var resultError = new ExampleEntitySaveEditDto();
                resultError.Erros.Add("Teste error");

                return resultError;
            }

            dto.ValidationErros = _validatorSaveEditDto.Validate(dto).Errors
                                                    .Select(s => new ValidationFailureDto(s.ErrorMessage, s.PropertyName))
                                                    .ToList();

            if (!dto.IsValid())
            {
                return dto;
            }

            var exampleEntity = CreateEntityByDto(dto);

            if (!exampleEntity.IsValid())
            {
                dto.Erros = exampleEntity.Errors;
                return dto;
            }

            _contextBase.ExamplesEntity.Add(exampleEntity);
            _contextBase.SaveChanges();

            return dto;
        }

        private ExampleEntity CreateEntityByDto(ExampleEntitySaveEditDto dto)
        {
            var result = new ExampleEntityBuilder()
                .WithName(dto.Name)
                .Build();

            return result;
        }
    }
}