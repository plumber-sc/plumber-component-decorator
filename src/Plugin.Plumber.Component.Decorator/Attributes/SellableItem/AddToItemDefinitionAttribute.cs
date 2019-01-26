using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;

namespace Plugin.Plumber.Component.Decorator.Attributes.SellableItem
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class AddToItemDefinitionAttribute : SellableItemAttributeBase
    {
        public string ItemDefinition { get; private set; }

        public AddToItemDefinitionAttribute(string itemDefinition, AddToSellableItemType addToSellableItem = AddToSellableItemType.SellableItemAndVariant) : base(addToSellableItem)
        {
            ItemDefinition = itemDefinition;
        }

        public override bool IsApplicableToEntity(CommerceEntity entity, string itemId)
        {
            if(!(entity is Sitecore.Commerce.Plugin.Catalog.SellableItem))
            {
                return false;
            }

            // Get the item definition
            var catalogs = entity.GetComponent<CatalogsComponent>();

            // TODO: What happens if a sellableitem is part of multiple catalogs?
            var catalog = catalogs.GetComponent<CatalogComponent>();
            var itemDefinition = catalog.ItemDefinition;

            return ItemDefinition == itemDefinition && IsApplicableComponent(itemId);
        }
    }
}
