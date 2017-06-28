using AutoMapper;
using Application.Base.Dto;
using WebApp.ViewModels.BaseViewModel;

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
        }
    }
}