using Newtonsoft.Json;
using OurHtagEditor.Models;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Extensions;

namespace OurHtagEditor.ValueConverters
{
    /// <summary>
    /// Represents a the property value converter for the OurHtagEditor
    /// </summary>
    public class OurHtagEditorValueConverter : PropertyValueConverterBase
    {
        /// <inheritdoc />
        public override bool IsConverter(IPublishedPropertyType propertyType)
            => propertyType.EditorAlias.InvariantEquals("ourHtagEditor");

        /// <inheritdoc />
        public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
            => typeof(Headline);

        /// <inheritdoc />
        public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType)
            => PropertyCacheLevel.Element;

        /// <inheritdoc />
        public override object ConvertSourceToIntermediate(
            IPublishedElement owner,
            IPublishedPropertyType propertyType,
            object source,
            bool preview) =>
            source?.ToString();

        /// <inheritdoc />
        public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel cacheLevel, object inter, bool preview)
        {
            if (string.IsNullOrWhiteSpace(inter?.ToString()))
            {
                return null;
            }

            Headline headline = JsonConvert.DeserializeObject<Headline>(inter.ToString());

            return headline;
        }
    }
}
