using Microsoft.Extensions.DependencyInjection;
using Sitecore.Framework.Conditions;

namespace Plugin.Plumber.Component.Decorator.Configuration
{
    public class PlumberServicesConfiguration : IPlumberServicesConfiguration
    {
        public PlumberServicesConfiguration(IServiceCollection services)
        {
            Condition.Requires<IServiceCollection>(services, nameof(services)).IsNotNull<IServiceCollection>();
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
