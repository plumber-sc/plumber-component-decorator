using Plugin.Plumber.Component.Decorator.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks.ViewValidators
{
    public abstract class ValidateEntityViewBaseBlock<EntityType> : PipelineBlock<EntityViewConditionsArgument, EntityViewConditionsArgument, CommercePipelineExecutionContext> where EntityType : CommerceEntity 
    {
        public override async Task<EntityViewConditionsArgument> Run(EntityViewConditionsArgument arg, CommercePipelineExecutionContext context)
        {
            var applicableViewNames = GetApplicableViewNames(context);

            arg.ValidateEntity(ent => ent is EntityType);
            arg.ValidateDisplayView(viewName => applicableViewNames.Count(av => viewName.Equals(av, StringComparison.OrdinalIgnoreCase)) > 0);
            arg.ValidateEditView(action => action.StartsWith("Edit-", StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(arg);
        }

        /// <summary>
        ///     Returns the name of the views that determines whether this is the display view for the entity
        /// </summary>
        /// <param name="context"></param>
        /// <returns>The name of the master view</returns>
        protected abstract List<string> GetApplicableViewNames(CommercePipelineExecutionContext context);

    }
}