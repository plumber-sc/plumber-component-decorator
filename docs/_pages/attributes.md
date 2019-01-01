---
title: All Available Attributes
toc: true
sidebar:
  title: "Sample Title"
  nav: sidebar
permalink: /docs/attributes/
---

You control how views of your components are created in the Sitecore Commerce Business Tools by adding attributes to your component. Below you will find the attributes you can use.

## Class Attributes
The following attributes can be added to the `Component` class. 

### [EntityViewAttribute](#EntityViewAttribute)

Add the `EntityVuewAttribute` to a class to indicate the class should be added as an entity view in the BizFx tools and set a user friendly view name.

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
| `DisplayName` | Name of the property shown in the Merchandising Manager      |
| `IsReadOnly`  | Set to `true` to indicate this property cannot be edited in the Merchandising Manager |
| `IsRequired`  | Set to `true` if this property is required.                  |

## Validation

You can also [add validation attributes](validation.md) to your component. 