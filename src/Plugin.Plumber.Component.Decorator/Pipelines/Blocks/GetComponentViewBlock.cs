﻿using System;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Linq;
using Plugin.Plumber.Component.Decorator.Attributes;
using System.Collections.Generic;
using Plugin.Plumber.Component.Decorator.Commanders;
using Plugin.Plumber.Component.Decorator.Pipelines.Arguments;

namespace Plugin.Plumber.Component.Decorator.Pipelines.Blocks
{
    /// <summary>
    ///     Creates the component view applicable to the selected sellable item.
    /// </summary>
    [PipelineDisplayName("GetComponentViewBlock")]
    public class GetComponentViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        private readonly ViewCommander viewCommander;
        private readonly ComponentViewCommander commander;

        public GetComponentViewBlock(ViewCommander viewCommander, ComponentViewCommander catalogSchemaCommander)
        {
            this.viewCommander = viewCommander;
            this.commander = catalogSchemaCommander;
        }

        public async override Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            Condition.Requires(entityView).IsNotNull($"{Name}: The argument cannot be null.");
            var request = this.viewCommander.CurrentEntityViewArgument(context.CommerceContext);

            if (request.Entity == null)
            {
                return entityView;
            }

            var entityViewConditionsArgument = new EntityViewConditionsArgument(request.Entity, request.ViewName, entityView.Action);
            var result = await commander.Pipeline<IGetApplicableViewConditionsPipeline>().Run(entityViewConditionsArgument, context);

            // Only proceed if the current entity is supported
            if (!result.IsSupportedEntity)
            {
                return entityView;
            }

            // Check if this is an edit view or display view
            if (!result.IsEditView && !result.IsDisplayView)
            {
                return entityView;
            }

            var commerceEntity = request.Entity;
            var components = commerceEntity.Components;

            // Get a list of all the component types that have been registered 
            var viewableComponentTypes = this.commander.GetViewableComponentTypes(commerceEntity, request.ItemId, context.CommerceContext);

            if (!string.IsNullOrWhiteSpace(entityView.ItemId) && commerceEntity is SellableItem)
            {
                var variation = ((SellableItem)commerceEntity).GetVariation(entityView.ItemId);
                if (variation != null)
                {
                    components = variation.ChildComponents;
                }
            }

            CreateEntityViews(entityView, result, components, viewableComponentTypes);

            return entityView;
        }

        private static void CreateEntityViews(EntityView entityView, EntityViewConditionsArgument result, IList<Sitecore.Commerce.Core.Component> components, IEnumerable<Type> viewableComponentTypes)
        {
            var targetView = entityView;

            foreach (var componentType in viewableComponentTypes)
            {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(componentType);

                var component = components.SingleOrDefault(comp => comp.GetType() == componentType);

                if (attrs.SingleOrDefault(attr => attr is EntityViewAttribute) is EntityViewAttribute entityViewAttribute)
                {
                    // Check if the edit action was requested for this specific component type
                    var isEditViewForThisComponent = !string.IsNullOrEmpty(entityView.Action) && entityView.Action.Equals($"Edit-{componentType.FullName}", StringComparison.OrdinalIgnoreCase);

                    if (result.IsDisplayView)
                    {
                        // Create a new view and add it to the current entity view.
                        var view = new EntityView
                        {
                            Name = componentType.FullName,
                            DisplayName = entityViewAttribute?.ViewName ?? componentType.Name,
                            EntityId = entityView.EntityId,
                            ItemId = entityView.ItemId,
                            EntityVersion = entityView.EntityVersion,
                            UiHint = entityViewAttribute?.UIHint ?? Constants.UIHint.Flat
                        };

                        entityView.ChildViews.Add(view);

                        targetView = view;

                        if (entityViewAttribute.UIHint == Constants.UIHint.List ||
                            entityViewAttribute.UIHint == Constants.UIHint.Table)
                        {   // The list requires a new child view for each "row" or "card" in the list.
                            var componentView = new EntityView
                            {
                                EntityId = entityView.EntityId,
                                ItemId = entityView.ItemId,
                                EntityVersion = entityView.EntityVersion,
                                Name = componentType.FullName
                            };

                            view.ChildViews.Add(componentView);

                            targetView = componentView;
                        }

                        
                    }
                    else
                    {
                        targetView.DisplayName = entityViewAttribute?.ViewName ?? componentType.Name;
                    }

                    if (result.IsDisplayView || (result.IsEditView && isEditViewForThisComponent))
                    {
                        AddPropertiesToView(targetView, componentType, component, isEditViewForThisComponent);
                    }
                }
            }
        }

        private static void AddPropertiesToView(EntityView targetView, Type componentType, Sitecore.Commerce.Core.Component component, bool isEditViewForThisComponent)
        {
            var props = componentType.GetProperties();

            foreach (var prop in props)
            {
                System.Attribute[] propAttributes = System.Attribute.GetCustomAttributes(prop);

                if (propAttributes.SingleOrDefault(attr => attr is PropertyAttribute) is PropertyAttribute propAttr)
                {
                    if (isEditViewForThisComponent || (!isEditViewForThisComponent && propAttr.ShowInList))
                    {
                        var viewProperty = new ViewProperty
                        {
                            Name = prop.Name,
                            DisplayName = propAttr.DisplayName,
                            RawValue = component != null ? prop.GetValue(component) : "",
                            OriginalType = prop.PropertyType.ToString(),
                            UiType = propAttr?.UIType,
                            IsReadOnly = !isEditViewForThisComponent && propAttr.IsReadOnly,
                            IsRequired = propAttr.IsRequired
                        };

                        targetView.Properties.Add(viewProperty);
                    }
                }
            }
        }
    }
}