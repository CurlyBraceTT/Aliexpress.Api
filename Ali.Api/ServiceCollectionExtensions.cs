using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aliexpress.Api
{
    /// <summary>
    /// Service Dependencies for Ali Api Client
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the ali client to the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>Services</returns>
        public static IServiceCollection AddAliClient(this IServiceCollection services, Action<AliexpressSettingsProvider> provider)
        {
            var defaults = new AliexpressSettingsProvider();
            provider.Invoke(defaults);
            services.AddSingleton<IAliexpressApiClient>(client => new AliexpressApiClient(defaults));
            return services;
        }
    }
}
