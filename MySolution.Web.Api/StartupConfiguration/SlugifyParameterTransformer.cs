using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace MySolution.Web.Api.StartupConfiguration
{
    internal sealed class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        #region Methods
        /// <summary>
        /// Transform the routes in kebab-case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string TransformOutbound(object value)
        {
            return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
        #endregion
    }
}