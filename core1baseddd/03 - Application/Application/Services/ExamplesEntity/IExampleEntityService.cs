using Application.Base.Dto;
using Application.Services.ExamplesEntity.Dto;
using System.Collections.Generic;

namespace Application.Services.ExamplesEntity
{
    public interface IExampleEntityService
    {
        ICollection<DropdownDto> GetDropdown();

        ExampleEntityGridDto GetGrid(int page = 1, string seach = null);

        ExampleEntitySaveEditDto Save(ExampleEntitySaveEditDto dto);
    }
}