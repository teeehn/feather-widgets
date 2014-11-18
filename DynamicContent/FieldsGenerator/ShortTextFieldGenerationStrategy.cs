﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.DynamicModules.Builder.Model;

namespace DynamicContent.FieldsGenerator
{
    /// <summary>
    /// This class represents field generation strategy for short text dynamic fields.
    /// </summary>
    public class ShortTextFieldGenerationStrategy : FieldGenerationStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortTextFieldGenerationStrategy"/> class.
        /// </summary>
        /// <param name="moduleType">Type of the module.</param>
        public ShortTextFieldGenerationStrategy(DynamicModuleType moduleType)
        {
            this.moduleType = moduleType;
        }

        /// <inheritdoc/>
        public override bool GetFieldCondition(DynamicModuleField field)
        {
            var condition = base.GetFieldCondition(field)
                && (field.FieldType == FieldType.ShortText || field.FieldType == FieldType.Guid)
                && field.Name != this.moduleType.MainShortTextFieldName;

            return condition;
        }

        /// <inheritdoc/>
        public override string GetFieldMarkup(DynamicModuleField field)
        {
            var markup = string.Format(ShortTextFieldGenerationStrategy.FieldMarkupTempalte, field.Name, field.Title);

            return markup;
        }

        private DynamicModuleType moduleType;
        private const string FieldMarkupTempalte = @"@Html.Sitefinity().ShortTextField((string)Model.Item.{0}, ""{0}"", fieldTitle: ""{1}"", cssClass: ""sfitemShortTxtWrp"")";
    }
}
