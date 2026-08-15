using System.Reflection;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Marks an array field or property so XML array-item overrides are added for its concrete derived element types.
	/// Candidate derived types are supplied when the object graph's overrides are built.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class AutoXmlArrayItemAttribute : AutoXmlAttribute
	{
		/// <summary>
		/// Throws because <see cref="AutoXmlArrayItemAttribute"/> can be applied only to fields and properties, not types.
		/// </summary>
		public override void VisitType(Type rootType, XmlAttributeOverrides overrides, Type[] allTypes)
			=> throw new InvalidOperationException("This method cannot be called for AutoXmlArrayItemAttribute");
		/// <summary>
		/// Adds an <see cref="XmlArrayItemAttribute"/> override for each non-abstract subclass of the property's array element type.
		/// </summary>
		public override void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, Type[] allTypes)
		{
			if (!property.PropertyType.IsArray)
				throw new InvalidOperationException($"AutoXmlArrayItemAttribute can only be applied on array types. type: {property.DeclaringType?.FullName}, member: {property.Name}");

			var elementType = property.PropertyType.GetElementType();

			var validTypes = allTypes.Where(x => !x.IsAbstract && x.IsSubclassOf(elementType!)).ToArray();

			if (validTypes.Length == 0)
				return;

			var attributes = overrides[property.DeclaringType!, property.Name];

			if (attributes == null)
				overrides.Add(property.DeclaringType!, property.Name, attributes = new XmlAttributes());

			foreach (var type in validTypes)
				attributes.XmlArrayItems.Add(new XmlArrayItemAttribute { Type = type });
		}
		/// <summary>
		/// Adds an <see cref="XmlArrayItemAttribute"/> override for each non-abstract subclass of the field's array element type.
		/// </summary>
		public override void VisitField(FieldInfo field, XmlAttributeOverrides overrides, Type[] allTypes)
		{
			if (!field.FieldType.IsArray)
				throw new InvalidOperationException($"AutoXmlArrayItemAttribute can only be applied on array types. type: {field.DeclaringType?.FullName}, member: {field.Name}");

			var elementType = field.FieldType.GetElementType();

			var validTypes = allTypes.Where(x => !x.IsAbstract && x.IsSubclassOf(elementType!)).ToArray();

			if (validTypes.Length == 0)
				return;

			var attributes = overrides[field.DeclaringType!, field.Name];

			if (attributes == null)
				overrides.Add(field.DeclaringType!, field.Name, attributes = new XmlAttributes());

			foreach (var type in validTypes)
				attributes.XmlArrayItems.Add(new XmlArrayItemAttribute { Type = type });
		}
	}
}
