using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plumber.Component.Decorator.Configuration
{
    public interface IPlumberServicesConfiguration
    {
        IServiceCollection Services { get; }
    }
}
