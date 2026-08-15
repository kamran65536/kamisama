using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Defines the base contract for attributes that add member-specific entries to an <see cref="XmlAttributeOverrides"/> collection.
	/// Concrete attributes control polymorphic element or array-item mappings.
	/// </summary>
	public abstract class AutoXmlAttribute  : Attribute
	{
		/// <summary>
		/// Applies this attribute's XML overrides while visiting the specified type.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="overrides"></param>
		/// <param name="allTypes"></param>
		public abstract void VisitType(Type type, XmlAttributeOverrides overrides, Type[] allTypes);
		/// <summary>
		/// Adds this attribute's XML overrides for the specified property.
		/// </summary>
		/// <param name="property"></param>
		/// <param name="overrides"></param>
		/// <param name="allTypes"></param>
		public abstract void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, Type[] allTypes);
		/// <summary>
		/// Adds this attribute's XML overrides for the specified field.
		/// </summary>
		/// <param name="field"></param>
		/// <param name="overrides"></param>
		/// <param name="allTypes"></param>
		public abstract void VisitField(FieldInfo field, XmlAttributeOverrides overrides, Type[] allTypes);
		/// <summary>
		/// Returns an array element type or the item type of an implemented <see cref="ICollection{T}"/> interface; otherwise, returns the supplied type unchanged.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		protected static Type? GetCollectionItemType(Type type)
		{
			if (type.IsArray)
				return type.GetElementType();
			else
			{
				var collectionInterface = type.GetInterfaces()
							.FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));

				if (collectionInterface != null)
					return collectionInterface.GetGenericArguments()[0];
			}

			return type;
		}
	}
}
