using Sitecore.Commerce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plumber.Component.Decorator.Attributes
{
    public abstract class ApplicabilityAttribute : System.Attribute
    {
        public bool IsApplicableToEntity(CommerceEntity entity)
        {
            return IsApplicableToEntity(entity, null);
        }

        public abstract bool IsApplicableToEntity(CommerceEntity entity, string itemId);
      
    }
}
