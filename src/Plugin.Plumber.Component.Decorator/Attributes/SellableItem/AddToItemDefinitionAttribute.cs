using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plumber.Component.Decorator.Attributes.SellableItem
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class AddToItemDefinitionAttribute : SellableItemAttributeBase
    {
        public string ItemDefinition { get; private set; }

        public AddToItemDefinitionAttribute(string itemDefinition, AddToSellableItem addToSellableItem = AddToSellableItem.SellableItemAndVariant) : base(addToSellableItem)
        {
            ItemDefinition = itemDefinition;
        }
    }
}
