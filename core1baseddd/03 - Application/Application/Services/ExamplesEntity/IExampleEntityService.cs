using Application.Base.Dto;
using System.Collections.Generic;

namespace Application.Services.ExamplesEntity
{
    public interface IExampleEntityService
    {
        ICollection<DropdownDto> GetDropdown();
    }
}