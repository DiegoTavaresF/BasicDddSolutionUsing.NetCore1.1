using Application.Base.Dto;
using Application.Services.ExamplesEntity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.ViewModels.BaseViewModel;
using WebApp.ViewModels.Home;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExampleEntityService _exampleEntityService;
        private readonly IMapper _mapper;

        public HomeController(IExampleEntityService exampleEntityService, IMapper mapper)
        {
            _exampleEntityService = exampleEntityService;
            _mapper = mapper;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Index()
        {
            var examplesDropdownDto = _exampleEntityService.GetDropdown();

            var result = new HomeIndexViewModel
            {
                ExamplesEntity = _mapper.Map<ICollection<DropdownDto>, ICollection<DropdownViewModel>>(examplesDropdownDto),
                SomeOtherDataFromSomeOtherService = "Some data from another service, just to show that ViewModel can be diferent from Dto" // _someService.GetSomeData();
            };

            return View(result);
        }
    }
}