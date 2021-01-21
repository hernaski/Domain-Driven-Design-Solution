using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySolution.Infrastructure.Context;

namespace MySolution.Ioc.ServiceCollectionExtensions
{
    public static class DbContext
    {
        #region Methods
        public static void AddDbContextMyDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDatabaseContext>(options => options.UseSqlServer(connectionString));
        }
        #endregion
    }
}