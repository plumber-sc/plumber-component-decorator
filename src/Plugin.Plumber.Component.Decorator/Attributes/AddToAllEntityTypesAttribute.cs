using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;

namespace Plugin.Plumber.Component.Decorator.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AddToAllEntityTypesAttribute : ApplicabilityAttribute
    {
        public override bool IsApplicableToEntity(CommerceEntity entity, string itemId)
        {
            return true;
        }
    }
}
