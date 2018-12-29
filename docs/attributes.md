## Attributes

Below you will find the attributes you can add to your components.

### [EntityViewAttribute](#EntityViewAttribute)

Add the `EntityVuewAttribute` to a class to indicate the class should be added as an entity view in the BizFx tools.

| Parameter  | Description                                           |
| ---------- | ----------------------------------------------------- |
| `ViewName` | Name of the view to show in the Merchandising Manager |

### [ItemDefinitionAttribute](#ItemDefinitionAttribute)

Add the `ItemDefinitionAttribute` to a component class to specify the item definition name this component should be added to.

| Parameter         | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| `ItemDefinitnion` | Name of the item definition for which to add this component to a sellable item |

### PropertyAttribute

Add a `PropertyAttribute` to each property of the class you want to be visible in the entity view in the Merchandising Manager.

| Parameter     | Description                                                  |
| ------------- | ------------------------------------------------------------ |
| `DisplayName` | Name of the property shown in the Merchandising Manager      |
| `IsReadOnly`  | Set to `true` to indicate this property cannot be edited in the Merchandising Manager |
| `IsRequired`  | Set to `true` if this property is required.                  |

## 