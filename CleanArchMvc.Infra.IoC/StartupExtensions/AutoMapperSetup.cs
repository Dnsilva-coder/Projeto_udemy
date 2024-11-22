using CleanArchMvc.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC.StartupExtensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfiguration.RegisterMappings());
        }
    }
}
