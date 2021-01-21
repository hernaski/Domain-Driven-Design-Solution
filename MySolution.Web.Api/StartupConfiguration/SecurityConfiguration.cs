using Microsoft.Extensions.DependencyInjection;

namespace MySolution.Web.Api.StartupConfiguration
{
    internal static class SecurityConfiguration
    {
        #region Variables
        internal const string CorsPolicyName = "MyCorsPolicy";
        #endregion

        #region Methods
        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/security/cors
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName, builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        #endregion
    }
}