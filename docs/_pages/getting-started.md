---
title: Getting Started
toc: false
permalink: /docs/getting-started/
classes: wide
---

Let's say you want to extend a sellable item with information on the warranty. You want to add two fields: 

* An integer value indicating the number of months warranty you get with the product;
* A piece of text (string) giving more information on the warranty.

This is what your component would look like:


```c#
using Sitecore.Commerce.Core;

namespace Plugin.Plumber.Catalog.Sample.Components
{
	public class WarrantyComponent : Component
	{
		public int WarrantyLengthInMonths { get; set; }

		public string WarrantyInformation { get; set; }
	}
}
```

Now, if you want users to be able to edit the warranty information in the Sitecore Commerce Busines Tools you would normally have to:

* Add a block to the `IGetEntityViewPipeline` to create an entity view for the Merchandising Manager
* Add a block to the `IPopulateEntityViewActionsPipeline` to add an action to the entity view so the user can edit the data.
* Add a block to the `IDoActionPipeline` to save the data the user edited.
* Add another block to the `IGetEntityViewPipeline` to handle updating the Sitecore template for a sellable item.

Instead, with __Plumber Component Decorator__ you do the following:

**Step 1**   
Add a dependency on the Plumber Component Decorator Nuget package. You can use the package manager console and execute the following command: `Install-Package Plugin.Plumber.Component.Decorator` or add a dependency on `Plugin.Plumber.Component.Decorator` using the Nuget Package Manager.

**Step 2**  
Add some attributes to the `WarrantyComponent` class so it looks like this:


```c#
using Sitecore.Commerce.Core;
using Plugin.Plumber.Component.Decorator.Attributes;

namespace Plugin.Plumber.Catalog.Sample.Components
{
	[EntityView("Warranty Information")]
	[AllSellableItems]
	public class WarrantyComponent : Component
    {
        [Property("Warranty length (months)"]
        public int WarrantyLengthInMonths { get; set; }

        [Property("Additional warranty information", )]
        public string WarrantyInformation { get; set; }
    }
}
```
This code does three things:

 - The `EntityView` attribute indicates you want to use this component in an entity view in the Merchandising Manager. 
 - The `AllSellableItems` attribute indicates this component should be added to all sellable items. There are other attributes that allow you to add the component to other entities.  
 - Add a `Property` attribute to each property you want to be viewable or editable (or both).

**Step 3**  
Plumber Component Decorator needs to know about the `WarrantyComponent`. To register your component add the following lines to your `ConfigureSitecore` class:

```c#
services.Plumber().ViewComponents(config => 
                                  config.AddViewComponent<WarrantyComponent>());
```
This code registers `WarrantyComponent` with Plumber Component Decorator. 
