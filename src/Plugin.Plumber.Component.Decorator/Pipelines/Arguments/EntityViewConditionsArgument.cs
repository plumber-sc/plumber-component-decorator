using Sitecore.Commerce.Core;
using System;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Arguments
{
    public class EntityViewConditionsArgument : PipelineArgument
    {
        public CommerceEntity Entity { get; private set; }
        public string ViewName { get; private set; }
        public string Action { get; private set; }

        public bool IsSupportedEntity { get; private set; } = false;
        public bool IsEditView { get; private set; } = false;
        public bool IsDisplayView { get; private set; } = false;

        public EntityViewConditionsArgument(CommerceEntity entity, string viewName, string action)
        {
            Entity = entity;
            ViewName = viewName;
            Action = action;
        }

        public void ValidateDisplayView(Func<string, bool> validate)
        {
            if(validate(ViewName))
            {
                IsDisplayView = true;
            }
        }

        public void ValidateEditView(Func<string, bool> validate)
        {
            if (validate(Action))
            {
                IsEditView = true;
            }
        }

        public void ValidateEntity(Func<CommerceEntity, bool> validate)
        {
            if (validate(Entity))
            {
                IsSupportedEntity = true;
            }
        }
    }
}
