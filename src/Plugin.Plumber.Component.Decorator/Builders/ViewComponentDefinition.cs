using Sitecore.Framework.Conditions;
using System;

namespace Plugin.Plumber.Component.Decorator.Builders
{
    public class ViewComponentDefinition<TComponent> : ViewComponentDefinition where TComponent : Sitecore.Commerce.Core.Component
    {
        
        public ViewComponentDefinition() : base(typeof(TComponent))
        {
        }
    }

    public abstract class ViewComponentDefinition
    {
        public Type Defines { get; }

        public ViewComponentDefinition(Type defines)
        {
            Condition.Requires<Type>(defines, nameof(defines)).IsNotNull<Type>();
            Defines = defines;
        }
    }
}