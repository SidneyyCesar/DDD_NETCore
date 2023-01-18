using DDD.Application;
using DDD.Application.Interfaces;
using DDD.Application.Services;
using DDD.Data.Repositories;
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Services;

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
        }
    }
}