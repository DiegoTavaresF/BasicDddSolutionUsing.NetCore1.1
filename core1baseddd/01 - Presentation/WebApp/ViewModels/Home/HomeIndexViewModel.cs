using System.Collections.Generic;
using WebApp.ViewModels.BaseViewModel;

namespace WebApp.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public ICollection<DropdownViewModel> ExamplesEntity { get; set; }
        public string SomeOtherDataFromSomeOtherService { get; set; }
    }
}