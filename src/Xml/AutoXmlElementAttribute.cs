using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Marks a field or property so XML-element overrides are added for its concrete derived value types.
	/// Collection members are mapped using their item type.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class AutoXmlElementAttribute : AutoXmlAttribute
	{
		/// <summary>
		/// Throws because <see cref="AutoXmlElementAttribute"/> can be applied only to fields and properties, not types.
		/// </summary>
		public override void VisitType(Type? rootType, XmlAttributeOverrides? overrides, Type[]? allTypes)
			=> throw new InvalidOperationException("This method cannot be called for AutoXmlElement");
		/// <summary>
		/// Adds a named <see cref="XmlElementAttribute"/> override for each non-abstract subclass of the property's value or collection-item type.
		/// </summary>
		public override void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, Type[] allTypes)
		{
			var elementType = GetCollectionItemType(property.PropertyType);

			var validTypes = allTypes.Where(x => !x.IsAbstract && x.IsSubclassOf(elementType!)).ToArray();

			if (validTypes.Length == 0)
				return;

			var attributes = overrides[property.DeclaringType!, property.Name];

			if (attributes == null)
				overrides.Add(property.DeclaringType!, property.Name, attributes = new XmlAttributes());

			foreach (var type in validTypes)
				attributes.XmlElements.Add(new XmlElementAttribute { Type = type, ElementName = type.Name });
		}
		/// <summary>
		/// Adds a named <see cref="XmlElementAttribute"/> override for each non-abstract subclass of the field's value or collection-item type.
		/// </summary>
		public override void VisitField(FieldInfo field, XmlAttributeOverrides overrides, Type[] allTypes)
		{
			var elementType = GetCollectionItemType(field.FieldType);

			var validTypes = allTypes.Where(x => !x.IsAbstract && x.IsSubclassOf(elementType!)).ToArray();

			if (validTypes.Length == 0)
				return;

			var attributes = overrides[field.DeclaringType!, field.Name];

			if (attributes == null)
				overrides.Add(field.DeclaringType!, field.Name, attributes = new XmlAttributes());

			foreach (var type in validTypes)
				attributes.XmlElements.Add(new XmlElementAttribute { Type = type, ElementName = type.Name });
		}
	}
}
