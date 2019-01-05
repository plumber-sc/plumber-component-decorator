---
title: Extensibility
toc: true
permalink: /docs/extensibility/
---
## Custom entities

Out-of-the-box Plumber Component Decorator supports the following entities:
* Catalog
* Category
* Customer
* Inventory Set
* Order
* Pricebook
* Pricecard
* Promotion book
* Promotion
* Sellable Item

You can extend it to your own entities by adding a block to the `IGetApplicableViewConditionsPipeline`.

This block should inherit from `ValidateEntityViewBaseBlock<T>` where _T_ is your entity type (it should inherity from `CommerceEntity`) and implement the `GetApplicableViewNames` method. This method should return a list of the view names Plumber should generate views for. Most of the times this is the master view. Your block should look like the below example.

Example:
```c#
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using System.Collections.Generic;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public class ValidateCatalogViewBlock : ValidateEntityViewBaseBlock<Sitecore.Commerce.Plugin.Catalog.Catalog>
    {
        protected override List<string> GetApplicableViewNames(CommercePipelineExecutionContext context)
        {
            var viewsPolicy = context.GetPolicy<KnownCatalogViewsPolicy>();
            return new List<string>() { viewsPolicy?.Master };
        }
    }
}

```
Then add the block to the `IGetApplicableViewConditionsPipeline`:
```c#
services.Pipelines(
        config =>
            config
                .ConfigurePipeline<IGetApplicableViewConditionsPipeline>(c =>
                {
                    c.Add<ValidateCatalogViewBlock>();
                })
    );
```