using Application.Base.Dto;
using Application.Services.ExamplesEntity.Dto;
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

        public ExampleEntitySaveEditDto Save(ExampleEntitySaveEditDto dto)
        {
            if (dto == null)
            {
                var resultError = new ExampleEntitySaveEditDto();
                resultError.Errors.Add(new ValidationFailureDto("", "Teste error validation"));

                return resultError;
            }

            dto.Errors = _validatorSaveEditDto.Validate(dto)
                                                .Errors
                                                .Select(s => new ValidationFailureDto(s.ErrorMessage, s.PropertyName))
                                                .ToList();

            if (!dto.IsValid())
            {
                return dto;
            }

            return dto;
        }
    }
}