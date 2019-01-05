using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using System.Collections.Generic;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public class ValidateOrderViewBlock : ValidateEntityViewBaseBlock<Order>
    {
        protected override List<string> GetApplicableViewNames(CommercePipelineExecutionContext context)
        {
            var orderViewsPolicy = context.GetPolicy<KnownOrderViewsPolicy>();
            return new List<string>() { orderViewsPolicy?.Master };
        }
    }
}
