using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;

namespace Plugin.Plumber.Component.Decorator.Attributes.SellableItem
{
    public enum AddToSellableItemType { SellableItemOnly, VariantOnly, SellableItemAndVariant }

    public abstract class SellableItemAttributeBase : ApplicabilityAttribute
    {
        public AddToSellableItemType AddToSellableItem { get; private set; }

        public SellableItemAttributeBase(AddToSellableItemType addToSellableItem = AddToSellableItemType.SellableItemAndVariant)
        {
            AddToSellableItem = addToSellableItem;
        }

        protected bool IsApplicableComponent(string itemId)
        {
            return (AddToSellableItem == AddToSellableItemType.SellableItemAndVariant) ||
                (AddToSellableItem == AddToSellableItemType.SellableItemOnly && string.IsNullOrEmpty(itemId)) ||
                (AddToSellableItem == AddToSellableItemType.VariantOnly && !string.IsNullOrEmpty(itemId));
        }
    }
}
