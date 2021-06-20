using AutoMapper;
using SampleProject.Entities.Concrete;
using SampleProject.WebApi.Models;

namespace SampleProject.WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Product, ProductViewModel>().ReverseMap();
            });
        }
    }
}