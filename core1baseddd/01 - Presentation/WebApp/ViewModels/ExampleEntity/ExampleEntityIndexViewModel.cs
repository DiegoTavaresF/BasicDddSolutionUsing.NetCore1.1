using System.Collections.Generic;
using WebApp.ViewModels.BaseViewModel;

namespace WebApp.ViewModels.ExampleEntity
{
    public class ExampleEntityIndexViewModel
    {
        public ICollection<DropdownViewModel> ExamplesEntity { get; set; }
        public string SomeOtherDataFromSomeOtherService { get; set; }
    }
}