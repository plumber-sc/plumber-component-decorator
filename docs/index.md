# Plumber Component Decorator for Sitecore Commerce

> Plugin for Sitecore Commerce that allows you to add attributes to your components for easy addition, viewing and editing in the Sitecore Commerce Business tools.

## What is Plumber Component Decorator?

In Sitecore Commerce you extend entities, like a sellable item, catalog, category, order or inventory by adding components to the entity. For instance, if you want to add information on warranty to a sellable item, you create a `WarrantyInformation` component and add it to the `SellableItem` entity. 

So far, so good, but it gets a little bit more complicated when you want to make this new component viewable and editable in the Sitecore Business tools. You need to extend the `IGetEntityViewPipeline` by adding a block that creates a view with the information from your `WarrantyInformation`  component. To edit the component you create another block that takes the entered information add puts it back in the component. And if you want to validate the entered data, you need to create another block that does the validation. And if you want to also have the new component appear as a data template in Sitecore, again, you need to create another block to do this.

## More information

[Getting Started](getting-started)

[Attributes](attributes.md)

[Validation](validation.md)
