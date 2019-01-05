using System.Collections.Generic;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Pricing;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public class ValidatePriceBookViewBlock : ValidateEntityViewBaseBlock<PriceBook>
    {
        protected override List<string> GetApplicableViewNames(CommercePipelineExecutionContext context)
        {
            var viewsPolicy = context.GetPolicy<KnownPricingViewsPolicy>();
            return new List<string>() { viewsPolicy?.Master };
        }
    }
}
