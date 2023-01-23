using AutoMapper;
using DDD.Application;
using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Data.Repositories;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Services;
using DDD.Presentation.AutoMapper;
using DDD.Presentation.Models;

namespace DDD.Presentation
{
    public static class Container
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IApplicationService<>), typeof(ApplicationService<>));
           services.AddTransient<ICustomerApplicationService, CustomerApplicationService>();
           services.AddTransient<IProductApplicationService, ProductApplicationService>();

           services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
           services.AddTransient<ICustomerService, CustomerService>();
           services.AddTransient<IProductService, ProductService>();

           services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
           services.AddTransient<ICustomerRepository, CustomerRepository>();
           services.AddTransient<IProductRepository, ProductRepository>();

            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Customer, CustomerVm>();
                config.CreateMap<CustomerVm, Customer>();

                config.CreateMap<Product, ProductVm>();
                config.CreateMap<ProductVm, Product>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}