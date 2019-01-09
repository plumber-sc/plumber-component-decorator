---
title: Attributes
toc: true
permalink: /docs/attributes/
---

You control how views of your components are created in the Sitecore Commerce Business Tools by adding attributes to your component. Below you will find the attributes you can use.

There are two types of attributes:
* [Class Attributes](#class-attributes) are applied to classes that inherit from the `Component` class.
* [Property Attributes](#property-attributes) are applied to properties.

## Class Attributes
The following attributes can be added to the `Component` class. 

### [EntityViewAttribute](#EntityViewAttribute)

Add the `EntityViewAttribute` to a class to indicate the class should be added as an entity view in the BizFx tools and set a user friendly view name.

| Parameter  | Description                                           |
| ---------- | ----------------------------------------------------- |
| `ViewName` | Name of the view. This name is shown in the Business Tools |

### [AddToAllEntityTypesAttribute](#AddToAllEntityTypesAttribute)

Add the `AddToAllEntityTypesAttribute` to a component class to specify the component should be added to all entity types. 

#### Example

```c#
    [AddToAllEntityTypes]
    [EntityView("Notes")]
    public class NotesComponent : Sitecore.Commerce.Core.Component
    {
        [Property("External Notes", isRequired: true, showInList: true)]
        public string ExternalNotes { get; set; } = string.Empty;

        [Property("Internal Notes")]
        [Required]
        public string InternalNotes { get; set; } = string.Empty;
    }
```

### [AddToEntityTypeAttribute](#AddToEntityTypeAttribute)

Add the `AddToEntityTypeAttribute` to a component class to specify the component should be added to a specific entity type. You specify the entity type in the `entityType` parameter. 

| Parameter         | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| `entityType` | Entity type to add the component to. The following entity types are supported: `Catalog`, `Category`, `Customer`, `InventorySet`, `Order`, `PriceBook`, `PriceCard`, `PromotionBook`, `Promotion`, `SellableItem`.|

#### Example
```c#
    [AddToEntityType(typeof(SellableItem))]
    [AddToEntityType(typeof(InventoryInformation))]
    [AddToEntityType(typeof(Promotion))]
    [AddToEntityType(typeof(Order))]
    [EntityView("Notes")]
    public class NotesComponent : Sitecore.Commerce.Core.Component
    {
        [Property("External Notes", isRequired: true, showInList: true)]
        public string ExternalNotes { get; set; } = string.Empty;

        [Property("Internal Notes")]
        [Required]
        public string InternalNotes { get; set; } = string.Empty;
    }
```

## Class attributes for use on catalog related components
The following attributes are specific to sellable items. Using these attributes you can specify to which sellable items the component is added.

### [AddToItemDefinitionAttribute](#AddToItemDefinitionAttribute)

Add the `AddToItemDefinitionAttribute` to a component class to specify the item definition name this component should be added to.

| Parameter         | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| `ItemDefinition` | Name of the item definition for which to add this component to a sellable item |
|`addToSellableItem`| Indicates whether the component should be added to the sellable item(`AddToSellableItem.SellableItemOnly`), the variant (`AddToSellableItem.VariantOnly`) or both (`AddToSellableItem.SellableItemAndVariant`, default). |

### [AddToSellableItemAttribute](#AddToSellableItemAttribute)

Use the `AddToSellableItemAttribute` to a component to add the component to all sellable items.

| Parameter         | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
|`addToSellableItem`| Indicates whether the component should be added to the sellable item(`AddToSellableItem.SellableItemOnly`), the variant (`AddToSellableItem.VariantOnly`) or both (`AddToSellableItem.SellableItemAndVariant`, default). |


## Property Attributes
The following attributes can be added to properties.

### PropertyAttribute

Add a `PropertyAttribute` to each property of the class you want to be visible in the entity view in the Merchandising Manager.

| Parameter     | Description                                                  |
| ------------- | ------------------------------------------------------------ |
| `DisplayName` | Name of the property shown in the Merchandising Manager. Default: Empty string. |
| `UIType`      | The UIType sets the control type that will be rendered on the entity view. Default: null. When no UIType is provided, the UI control is based off the data type that is set against the property. You can find a list of possible UI types on Andrew Sutherlands blog titled [Business Tools UI Hints and UI Types](http://andrewsutherland.azurewebsites.net/2018/10/02/business-tools-ui-hints-and-ui-types/) (scroll down to the UI Types section) |
| `IsReadOnly`  | Set to `true` to indicate this property cannot be edited in the Merchandising Manager. Default: `false`. |
| `IsRequired`  | Set to `true` if this property is required. Default: `false`. |
| `ShowInList`  | Set to `false` if this property should not be shown in the list view. Default: `true`.|

## Validation

You can also [add validation attributes](validation.md) to your component. 