using System;
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
	}
}
