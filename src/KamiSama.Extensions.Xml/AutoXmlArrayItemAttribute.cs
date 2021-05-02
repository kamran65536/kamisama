using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Automatically adds xml array items
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class AutoXmlArrayItemAttribute : AutoXmlAttribute
	{
		/// <inheritdoc />
		public override void VisitType(Type rootType, XmlAttributeOverrides overrides, Type[] allTypes)
			=> throw new InvalidOperationException("This method cannot be called for AutoXmlElement");
		/// <inheritdoc />
		public override void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, Type[] allTypes)
		{
			if (!property.PropertyType.IsArray)
				throw new InvalidOperationException($"AutoXmlArrayItemAttribute can only be applied on array types. type: {property.DeclaringType.FullName}, member: {property.Name}");

			var elementType = property.PropertyType.GetElementType();

			var validTypes = allTypes.Where(x => !x.IsAbstract && x.IsSubclassOf(elementType)).ToArray();

			if (validTypes.Length == 0)
				return;

			var attributes = overrides[property.DeclaringType, property.Name];

			if (attributes == null)
				overrides.Add(property.DeclaringType, property.Name, attributes = new XmlAttributes());

			foreach (var type in validTypes)
				attributes.XmlArrayItems.Add(new XmlArrayItemAttribute { Type = type });
		}
		/// <inheritdoc />
		public override void VisitField(FieldInfo field, XmlAttributeOverrides overrides, Type[] allTypes)
		{
			if (!field.FieldType.IsArray)
				throw new InvalidOperationException($"AutoXmlArrayItemAttribute can only be applied on array types. type: {field.DeclaringType.FullName}, member: {field.Name}");

			var elementType = field.FieldType.GetElementType();

			var validTypes = allTypes.Where(x => !x.IsAbstract && x.IsSubclassOf(elementType)).ToArray();

			if (validTypes.Length == 0)
				return;

			var attributes = overrides[field.DeclaringType, field.Name];

			if (attributes == null)
				overrides.Add(field.DeclaringType, field.Name, attributes = new XmlAttributes());

			foreach (var type in validTypes)
				attributes.XmlArrayItems.Add(new XmlArrayItemAttribute { Type = type });
		}
	}
}
