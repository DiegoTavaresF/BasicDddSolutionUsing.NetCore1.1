using System.Collections.Generic;

namespace WebApp.ViewModels.ExampleEntity
{
    public class ExampleEntityGridViewModel
    {
        public IEnumerable<ExampleEntityGridDataViewModel> Data { get; set; }
        public int Page { get; set; }
        public string Search { get; set; }
    }
}