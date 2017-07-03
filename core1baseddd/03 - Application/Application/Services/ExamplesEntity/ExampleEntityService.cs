using Application.Base.Dto;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.ExamplesEntity
{
    public class ExampleEntityService : IExampleEntityService
    {
        private readonly IContextBase _contextBase;

        public ExampleEntityService(IContextBase contextBase)
        {
            _contextBase = contextBase;
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
    }
}