using Application.Base.Dto;
using Domain.Entities.ExamplesEntity;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
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
            var exampleEntity = new ExampleEntity { Nome = DateTime.Now.ToString() };

            return _contextBase.ExamplesEntity
                .AsNoTracking()
                .OrderBy(w => w.Nome)
                .Select(s => new DropdownDto
                {
                    Id = s.Id,
                    Nome = s.Nome
                }).ToList();
        }
    }
}