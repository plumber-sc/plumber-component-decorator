﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plumber.Component.Decorator.Constants
{
    public static class Pipelines
    {
        /// <summary>
        ///     The names of the Plumber.Catalog blocks.
        /// </summary>
        public static class Blocks
        {
            public const string DoActionAddValidationConstraintBlock = "Plumber.Catalog.DoActionAddValidationConstraintBlock";
            public const string DoActionEditComponentBlock = "Plumber.Catalog.DoActionEditComponentBlock";
            public const string GetAddMinMaxPropertyConstraintViewBlock = "Plumber.Catalog.GetAddMinMaxPropertyConstraintViewBlock";
            public const string GetComponentConnectViewBaseBlock = "Plumber.Catalog.GetComponentConnectViewBaseBlock";
            public const string GetComponentViewBlock = "Plumber.Catalog.GetComponentViewBlock";
            public const string GetRawSellableItemViewBlock = "Plumber.Catalog.GetRawSellableItemViewBlock";
            public const string PopulateComponentActionsBlock = "Plumber.Catalog.PopulateComponentActionsBlock";
            public const string ConfigureServiceApiBlock = "Plumber.Catalog.ConfigureServiceApiBlock";
        }

    }
}
