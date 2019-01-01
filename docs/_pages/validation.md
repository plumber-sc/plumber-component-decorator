---
title: Component Validation
toc: true
sidebar:
  title: "Sample Title"
  nav: sidebar
permalink: /docs/validation/
---
You can add [validation attributes](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2) from the `System.ComponentModel.DataAnnotations` namespace to the properties of your components so they can be automatically validated in the Sitecore Commerce Business Tools. 

Plumber Component Decorator adds the `DoActionAddValidationConstraintsBlock` to the `IDoActionPipeline` pipeline, which will validate the entered data and adds error messages if necessary.

Below is an example of using the data annotations attributes:

```c#
using Sitecore.Commerce.Core;
using Plugin.Plumber.Catalog.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Plugin.Plumber.Catalog.Sample.Components
{
    [EntityView("Warranty Information")]
    [AllSellableItems]
    public class WarrantyComponent : Component
    {
        [Property("Warranty length (months)", showInList:true)]
        [Range(12, 24)]
        public int WarrantyLengthInMonths { get; set; }

        [Property("Additional warranty information (Days|Months|Years)", showInList:true)]
        [RegularExpression(pattern: "^(Days|Months|Years)$",
            ErrorMessage ="Valid values are: Days, Months, Years")]
        public string WarrantyInformation { get; set; }
    }
}
```

In this example: 

* the`WarrantyLengthInMonths` property has to be in the range 12 to 24;
* the `WarrantyInformation` property is validated by a `RegularExpression` validator and has to be one of `Days`, `Months` or `Years`.

#### More information:  
[Model validation in ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2)