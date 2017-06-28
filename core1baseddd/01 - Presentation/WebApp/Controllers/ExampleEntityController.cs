using Application.Base.Dto;
using Application.Services.ExamplesEntity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.ViewModels.BaseViewModel;
using WebApp.ViewModels.ExampleEntity;

namespace WebApp.Controllers
{
    public class ExampleEntityController : Controller
    {
        private readonly IExampleEntityService _exampleEntityService;
        private readonly IMapper _mapper;

        public ExampleEntityController(IExampleEntityService exampleEntityService, IMapper mapper)
        {
            _exampleEntityService = exampleEntityService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var examplesDropdownDto = _exampleEntityService.GetDropdown();

            var result = new ExampleEntityIndexViewModel
            {
                ExamplesEntity = _mapper.Map<ICollection<DropdownDto>, ICollection<DropdownViewModel>>(examplesDropdownDto),
                SomeOtherDataFromSomeOtherService = "Some data from another service, just to show that ViewModel can be diferent from Dto"
            };

            return View(result);
        }
    }
}