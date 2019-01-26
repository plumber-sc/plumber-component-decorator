// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleComponent.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Plugin.Plumber.Component.Sample.Components
{
    using Plugin.Plumber.Component.Decorator.Attributes;
    using Plugin.Plumber.Component.Decorator.Attributes.SellableItem;
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// The SampleComponent.
    /// </summary>
    [EntityView("Sample")]
    [AddToItemDefinition("Refrigerator", AddToSellableItemType.VariantOnly)]
    public class SampleComponent : Component
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Property("Description of the sample component", showInList: true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        [Property("Comment for the sample component")]
        public string Comment { get; set; }

    }
}