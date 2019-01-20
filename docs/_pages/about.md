---
title: About
toc: false
permalink: /docs/about/
classes: wide
---
## What is Plumber Component Decorator?

**Plumber Component Decorator** helps you to make components visible and editable in the Sitecore Commerce Business Tools and makes it easier to extend entities with new components.

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

