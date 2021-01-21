using HtagGridEditor.Models;
using Newtonsoft.Json;
using System;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace HtagGridEditor.ValueConverters
{
    /// <summary>
    /// Represents a the property value converter for the HtagGridEditor
    /// </summary>
    public class HtagGridEditorValueConverter : PropertyValueConverterBase
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
