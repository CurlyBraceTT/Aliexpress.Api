using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ali.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAliClient(this IServiceCollection services, Action<AliSettingsProvider> provider)
        {
            var defaults = new AliSettingsProvider();
            provider.Invoke(defaults);
            services.AddSingleton<IAliApiClient>(client => new AliApiClient(defaults));
            return services;
        }
    }
}
