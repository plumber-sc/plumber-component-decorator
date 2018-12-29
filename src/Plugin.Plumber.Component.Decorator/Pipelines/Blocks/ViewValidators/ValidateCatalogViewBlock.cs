using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public class ValidateCatalogViewBlock : ValidateEntityViewBaseBlock<Sitecore.Commerce.Plugin.Catalog.Catalog>
    {
        protected override string GetMasterViewName(CommercePipelineExecutionContext context)
        {
            var viewsPolicy = context.GetPolicy<KnownCatalogViewsPolicy>();
            return viewsPolicy?.Master;
        }
    }
}
