using AutoMapper;
using Application.Base.Dto;
using WebApp.ViewModels.BaseViewModel;
using WebApp.ViewModels.ExampleEntity;
using Application.Services.ExamplesEntity.Dto;

namespace WebApp.Mapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            config.AssertConfigurationIsValid();

            return config;
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DropdownDto, DropdownViewModel>();

            CreateMap<ExampleEntitySaveEditDto, ExampleEntitySaveEditViewModel>();
            CreateMap<ExampleEntitySaveEditViewModel, ExampleEntitySaveEditDto>();

            CreateMap<ExampleEntityGridDataDto, ExampleEntityGridDataViewModel>();
            CreateMap<ExampleEntityGridDto, ExampleEntityGridViewModel>();
        }
    }
}