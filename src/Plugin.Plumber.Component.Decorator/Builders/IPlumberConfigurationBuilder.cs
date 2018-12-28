namespace Plugin.Plumber.Component.Decorator.Builders
{
    public interface IPlumberConfigurationBuilder
    {
        PlumberConfigurationBuilder AddViewComponent<TViewComponent>() where TViewComponent: Sitecore.Commerce.Core.Component;
    }
}