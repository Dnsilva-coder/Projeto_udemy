using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvc.Infra.IoC.StartupExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegiterServices(IServiceCollection service)
        {
            service.AddAutoMapperSetup();

            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();

            service.AddScoped<IProducRepository, ProductRepository>();
            service.AddScoped<IProductService, ProductService>();

            service.AddScoped(typeof(DomainToDTOMappingProfile));

            service.AddDbContext<ApplicationDbContext>();
        }
    }
}
