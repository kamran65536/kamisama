using System.Reflection;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Provides extension methods that populate <see cref="XmlAttributeOverrides"/> from <see cref="AutoXmlElementAttribute"/> and <see cref="AutoXmlArrayItemAttribute"/> annotations.
	/// Use the resulting overrides to construct an <see cref="XmlSerializer"/> for polymorphic object graphs.
	/// </summary>
	public static class XmlAttributeOverridesExtensions
	{
		/// <summary>
		/// Populates the overrides for the root object graph using concrete derived types discovered in the specified assemblies.
		/// </summary>
		/// <param name="overrides"></param>
		/// <param name="assemblies"></param>
		/// <param name="rootType"></param>
		public static void AddAutoXmlAttributes(this XmlAttributeOverrides overrides, Type rootType, Assembly[]? assemblies)
		{
			assemblies ??= [];

			var allTypes = assemblies.SelectMany(a => a.GetTypes()).ToArray();

			if (allTypes.Length == 0)
				return;

			AddAutoXmlAttributes(overrides, rootType, allTypes);
		}
		/// <summary>
		/// Populates the overrides for the root object graph using the supplied types as candidates for polymorphic members.
		/// </summary>
		public static void AddAutoXmlAttributes(this XmlAttributeOverrides overrides, Type rootType, Type[] allTypes)
		{
			var visitedTypes = new HashSet<Type>();

			VisitType(rootType, overrides, visitedTypes, allTypes);
		}
		/// <summary>
		/// Visits the type and adds necessary overrides
		/// </summary>
		/// <param name="rootType"></param>
		/// <param name="overrides"></param>
		/// <param name="visitedTypes"></param>
		/// <param name="allTypes"></param>
		internal static void VisitType(Type rootType, XmlAttributeOverrides overrides, HashSet<Type> visitedTypes, Type[] allTypes)
		{
			if (rootType.IsArray)
			{
				VisitType(rootType.GetElementType()!, overrides, visitedTypes, allTypes);

				return;
			}
			if (visitedTypes.Contains(rootType))
				return;
			visitedTypes.Add(rootType);

			foreach (var attr in rootType.GetCustomAttributes<AutoXmlAttribute>())
				attr.VisitType(rootType, overrides, allTypes);

			foreach (var property in rootType.GetProperties())
				VisitProperty(property, overrides, visitedTypes, allTypes);
			foreach (var field in rootType.GetFields())
				VisitField(field, overrides, visitedTypes, allTypes);
		}
		/// <summary>
		/// Visits the field and adds necessary overrides
		/// </summary>
		/// <param name="field"></param>
		/// <param name="overrides"></param>
		/// <param name="visitedTypes"></param>
		/// <param name="allTypes"></param>
		internal static void VisitField(FieldInfo field, XmlAttributeOverrides overrides, HashSet<Type> visitedTypes, Type[] allTypes)
		{
			if (field.FieldType.IsPrimitive)
				return;

			foreach (AutoXmlAttribute attr in field.GetCustomAttributes<AutoXmlAttribute>())
				attr.VisitField(field, overrides, allTypes);
			
			VisitType(field.FieldType, overrides, visitedTypes, allTypes);
		}
		/// <summary>
		/// Visits the property and adds necessary overrides
		/// </summary>
		/// <param name="property"></param>
		/// <param name="overrides"></param>
		/// <param name="visitedTypes"></param>
		/// <param name="allTypes"></param>
		private static void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, HashSet<Type> visitedTypes, Type[] allTypes)
		{
			if (property.PropertyType.IsPrimitive)
				return;

			foreach (var attr in property.GetCustomAttributes<AutoXmlAttribute>())
				attr.VisitProperty(property, overrides, allTypes);

			VisitType(property.PropertyType, overrides, visitedTypes, allTypes);
		}
	}
}
