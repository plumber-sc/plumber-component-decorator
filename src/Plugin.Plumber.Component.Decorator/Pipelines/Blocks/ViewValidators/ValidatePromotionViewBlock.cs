using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Promotions;
using System.Collections.Generic;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public class ValidatePromotionViewBlock : ValidateEntityViewBaseBlock<Promotion>
    {
        protected override List<string> GetApplicableViewNames(CommercePipelineExecutionContext context)
        {
            var viewsPolicy = context.GetPolicy<KnownPromotionsViewsPolicy>();
            return new List<string>() { viewsPolicy?.Master };
        }
    }
}
