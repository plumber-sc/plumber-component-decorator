[![Build status](https://ci.appveyor.com/api/projects/status/gqdjcjwgyfkb8819?svg=true)](https://ci.appveyor.com/project/ewerkman/plumber-catalog-af9f9)


# Plumber Component Decorator for Sitecore Commerce

> Plugin for Sitecore Commerce that allows you to add attributes to your components for easy addition, viewing and editing in the Sitecore Commerce Business tools.

## What is Plumber Component Decorator?

In Sitecore Commerce you extend entities, like a sellable item, catalog, category, order or inventory by adding components to the entity. For instance, if you want to add information on warranty to a sellable item, you create a `WarrantyInformation` component and add it to the `SellableItem` entity. 

So far, so good, but it gets a little bit more complicated when you want to make this new component viewable and editable in the Sitecore Business tools. You need to extend the `IGetEntityViewPipeline` by adding a block that creates a view with the information from your `WarrantyInformation`  component. To edit the component you create another block that takes the entered information add puts it back in the component. And if you want to validate the entered data, you need to create another block that does the validation. And if you want to also have the new component appear as a data template in Sitecore, again, you need to create another block to do this.

### Add a viewable and editable component in two easy steps

Using Plumber Component Decorator you can do all this and more in two steps:

1. Create your component and decorate your component with attributes;
2. Register your component with **Plumber Component Decorator**.

Plumber Component Decorator automatically adds pipeline blocks to the `IGetEntityViewPipeline` (which is responsible for providing the views for the Business Tools) that take the information in the attributes from your component and adds the appropriate views and actions to the business tools. It also helps you generate the appropriate data templates for use of catalog, category or sellable item components in Sitecore.

This means you just add attributes to your catalog component class and **Plumber Component Decorator** will take care of the rest.

## How to use it? 

Add a Nuget dependency on `Plugin.Plumber.Component.Decorator` to the plugin that contains your components:

* From the package manager console: `Install-Package Plugin.Plumber.Component.Decorator` 
* Using the Nuget package manager add a dependency on `Plugin.Plumber.Component.Decorator`.

## Getting started

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

Now, if you want users to be able to edit the warranty information in the Merchandising Manager you would normally have to:

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


