using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySolution.Ioc.ServiceCollectionExtensions;
using MySolution.Web.Api.StartupConfiguration;

namespace MySolution.Web.Api
{
    public class Startup
    {
        #region Properties
        public IConfiguration Configuration { get; }
        public string MyConnectionString
        {
            get
            {
                string myConnExample = Configuration.GetConnectionString("MyConnectionString");

                // DELETE THIS LINE BELOW - JUST FOR USE DATABASE EXAMPLE
                myConnExample = myConnExample.Replace("{%ROOT_PROJECT%}", System.IO.Directory.GetCurrentDirectory());
                // DELETE THIS LINE ABOVE - JUST FOR USE DATABASE EXAMPLE

                return myConnExample;
            }
        }
        #endregion

        #region Constructors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextMyDatabase(MyConnectionString);
            services.AddAutoMapper(typeof(Startup));
            services.AddOptions();
            services.AddLocalization();
            services.AddSwaggerGen();
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            });

            services.ConfigureCors();
            services.ConfigureDependencyInjectionMySolution();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureLocalization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(SwaggerConfiguration.EndpointSwaggerJson, SwaggerConfiguration.NameApiSwagger));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(SecurityConfiguration.CorsPolicyName);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}