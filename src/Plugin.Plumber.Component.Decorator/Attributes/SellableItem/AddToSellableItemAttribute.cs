using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;

namespace Plugin.Plumber.Component.Decorator.Attributes.SellableItem
{
    /// <summary>
    ///     Attribute to indicate the component to which the attribute is attached should 
    ///     be added to all sellable items.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AddToSellableItemAttribute : SellableItemAttributeBase
    {
        public AddToSellableItemAttribute(AddToSellableItemType addToSellableItem = AddToSellableItemType.SellableItemAndVariant) : base(addToSellableItem)
        {
        }

        public override bool IsApplicableToEntity(CommerceEntity entity, string itemId)
        {
            return entity is Sitecore.Commerce.Plugin.Catalog.SellableItem;
        }
    }
}
