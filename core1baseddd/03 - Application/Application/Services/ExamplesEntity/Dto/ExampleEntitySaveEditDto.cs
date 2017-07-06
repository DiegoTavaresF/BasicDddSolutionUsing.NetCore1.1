using Application.Base.Dto;
using System;

namespace Application.Services.ExamplesEntity.Dto
{
    public class ExampleEntitySaveEditDto : MainDtoError
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}