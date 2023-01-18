using AutoMapper;
using DDD.Domain.Entities;
using DDD.Presentation.Models;

namespace DDD.Presentation.AutoMapper
{
    public class ModelToDomainMappingProfile: Profile
    {
        public ModelToDomainMappingProfile()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerVm, Customer>();
                config.CreateMap<ProductVm, Product>();
            });
        }
    }
}