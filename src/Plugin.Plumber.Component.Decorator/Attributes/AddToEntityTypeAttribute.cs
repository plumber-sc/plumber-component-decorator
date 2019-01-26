using System;
using Sitecore.Commerce.Core;

namespace Plugin.Plumber.Component.Decorator.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AddToEntityTypeAttribute : ApplicabilityAttribute
    {
        public Type EntityType { get; set; }

        public AddToEntityTypeAttribute(Type entityType)
        {
            this.EntityType = entityType;
        }

        public override bool IsApplicableToEntity(CommerceEntity entity, string itemId)
        {
            return entity.GetType() == EntityType;
        }
    }
}
