using Plugin.Plumber.Component.Decorator.Builders;
using Plugin.Plumber.Component.Decorator.Configuration;
using Sitecore.Framework.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PlumberServicesConfigurationExtensions
    {
        public static IPlumberServicesConfiguration ViewComponents(this IPlumberServicesConfiguration builder, Action<PlumberConfigurationBuilder> configure = null)
        {
            Condition.Requires<IPlumberServicesConfiguration>(builder, nameof(builder)).IsNotNull<IPlumberServicesConfiguration>();

            configure?.Invoke(new PlumberConfigurationBuilder(builder.Services));
            return builder;
        }
    }


}
