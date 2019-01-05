using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Inventory;
using System.Collections.Generic;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public class ValidateInventorySetBlock : ValidateEntityViewBaseBlock<InventorySet>
    {
        protected override List<string> GetApplicableViewNames(CommercePipelineExecutionContext context)
        {
            var viewsPolicy = context.GetPolicy<KnownInventoryViewsPolicy>();
            return new List<string>() { viewsPolicy?.Master };
        }
    }
}
