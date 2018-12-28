using Plugin.Plumber.Component.Decorator.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IPlumberServicesConfiguration Plumber(this IServiceCollection services)
        {
            return (IPlumberServicesConfiguration)new PlumberServicesConfiguration(services);
        }
    }
}
