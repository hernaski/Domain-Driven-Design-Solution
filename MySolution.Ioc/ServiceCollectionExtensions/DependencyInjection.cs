using Microsoft.Extensions.DependencyInjection;
using MySolution.Domain.Interfaces.Repository;
using MySolution.Domain.Interfaces.Services;
using MySolution.Infrastructure.Repository;
using MySolution.Services;

namespace MySolution.Ioc.ServiceCollectionExtensions
{
    public static class DependencyInjection
    {
        #region Methods
        public static void ConfigureDependencyInjectionMySolution(this IServiceCollection services)
        {
            // Services
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IProductServices, ProductServices>();

            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        #endregion
    }
}