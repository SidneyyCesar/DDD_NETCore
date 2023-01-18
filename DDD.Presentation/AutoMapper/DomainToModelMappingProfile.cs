using AutoMapper;
using DDD.Domain.Entities;
using DDD.Presentation.Models;

namespace DDD.Presentation.AutoMapper
{
    public class DomainToModelMappingProfile: Profile
    {
        public DomainToModelMappingProfile()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Customer, CustomerVm>();
                config.CreateMap<Product, ProductVm>();
            });
        }
    }
}