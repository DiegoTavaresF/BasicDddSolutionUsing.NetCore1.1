using System.Collections.Generic;

namespace Application.Services.ExamplesEntity.Dto
{
    public class ExampleEntityGridDto
    {
        public IEnumerable<ExampleEntityGridDataDto> Data { get; set; }
        public int Page { get; set; }
        public string Search { get; set; }
    }
}