using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace MySolution.Web.Api.StartupConfiguration
{
    internal static class LocalizationConfiguration
    {
        #region Variables
        public const string MainCulture = "en-US";
        #endregion

        #region Methods
        public static void ConfigureLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new[] { new CultureInfo(MainCulture) };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(MainCulture),
                SupportedCultures = supportedCultures,
                FallBackToParentCultures = false
            });

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(MainCulture);
        }
        #endregion
    }
}