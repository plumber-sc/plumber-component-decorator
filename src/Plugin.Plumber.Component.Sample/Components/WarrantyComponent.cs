using System;
using System.ComponentModel.DataAnnotations;
using Plugin.Plumber.Component.Decorator.Attributes;
using Plugin.Plumber.Component.Decorator.Attributes.SellableItem;

namespace Plugin.Plumber.Component.Sample.Components
{
    [EntityView(viewName:"Warranty Information")]
    [AddToSellableItem(AddToSellableItemType.SellableItemOnly)]
    public class WarrantyComponent : Sitecore.Commerce.Core.Component
    {
        [Property("Warranty length (months)", showInList:true)]
        [Range(12, 24)]
        public long WarrantyLengthInMonths { get; set; }

        [Property("Additional warranty information", showInList:true)]
        [RegularExpression(pattern: "^(Days|Months|Years)$",
            ErrorMessage ="Valid values are: Days, Months, Years")]
        public string WarrantyInformation { get; set; }

        [Property("Item has a waranty", showInList:true)]
        public bool HasWarranty { get; set; }

        [Property("Warranty ends at", showInList: true)]
        public DateTimeOffset WarrantyEndDate { get; set; }

        [Property("Price for extra warranty", showInList:true)]
        public Decimal ExtraWarrantyPrice { get; set; }
    }
}
