using Application.Base.Dto;
using Application.Services.ExamplesEntity;
using Application.Services.ExamplesEntity.Dto;
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
            var resultDto = _exampleEntityService.GetGrid();

            var resultViewModel = _mapper.Map<ExampleEntityGridDto, ExampleEntityGridViewModel>(resultDto);

            return View(resultViewModel);
        }

        public IActionResult Save()
        {
            var resultViewModel = new ExampleEntitySaveEditViewModel();

            return View(resultViewModel);
        }

        [HttpPost]
        public IActionResult Save(ExampleEntitySaveEditViewModel data)
        {
            var dto = _mapper.Map<ExampleEntitySaveEditViewModel, ExampleEntitySaveEditDto>(data);

            var resultDto = _exampleEntityService.Save(dto);
            var resultViewModel = _mapper.Map<ExampleEntitySaveEditDto, ExampleEntitySaveEditViewModel>(resultDto);

            if (!resultDto.IsValid())
            {
                SetErros(resultDto.ValidationErros);
                return View(resultViewModel);
            }

            return RedirectToAction("Index");
        }

        private void SetErros(IList<ValidationFailureDto> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}