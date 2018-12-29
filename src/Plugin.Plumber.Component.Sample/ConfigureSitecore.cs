namespace Plugin.Plumber.Component.Sample
{
    using Microsoft.Extensions.DependencyInjection;
    using Plugin.Plumber.Component.Sample.Components;
    using Sitecore.Framework.Configuration;

    /// <summary>
    /// The configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Plumber().ViewComponents(config =>
                config.AddViewComponent<WarrantyComponent>()
                .AddViewComponent<NotesComponent>()
                .AddViewComponent<SampleComponent>());
        }
    }
}