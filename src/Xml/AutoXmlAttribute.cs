using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace KamiSama.Extensions
{
	/// <summary>
	/// base class for all Auto...Attributes like AutoXmlElement, AutoXmlArrayItem
	/// </summary>
	public abstract class AutoXmlAttribute  : Attribute
	{
		/// <summary>
		/// Called when a type is visited to add proper items to <see cref="XmlAttributeOverrides"/>
		/// </summary>
		/// <param name="type"></param>
		/// <param name="overrides"></param>
		/// <param name="allTypes"></param>
		public abstract void VisitType(Type type, XmlAttributeOverrides overrides, Type[] allTypes);
		/// <summary>
		/// Called when a property is visited to add proper items to <see cref="XmlAttributeOverrides"/>
		/// </summary>
		/// <param name="property"></param>
		/// <param name="overrides"></param>
		/// <param name="allTypes"></param>
		public abstract void VisitProperty(PropertyInfo property, XmlAttributeOverrides overrides, Type[] allTypes);
		/// <summary>
		/// Called when a field is visited to add proper items to <see cref="XmlAttributeOverrides"/>
		/// </summary>
		/// <param name="field"></param>
		/// <param name="overrides"></param>
		/// <param name="allTypes"></param>
		public abstract void VisitField(FieldInfo field, XmlAttributeOverrides overrides, Type[] allTypes);
		/// <summary>
		/// returns collection item type if the <paramref name="type"/> is <see cref="Array"/> or <see cref="ICollection{T}"/>
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
