using Plugin.Plumber.Component.Decorator.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Customers;
using Sitecore.Framework.Pipelines;
using System;
using System.Threading.Tasks;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public class ValidateCustomerViewBlock : ValidateEntityViewBaseBlock<Customer>
    {
        protected override string GetMasterViewName(CommercePipelineExecutionContext context)
        {
            var viewsPolicy = context.GetPolicy<KnownCustomerViewsPolicy>();
            return viewsPolicy?.Master;
        }
    }
}
