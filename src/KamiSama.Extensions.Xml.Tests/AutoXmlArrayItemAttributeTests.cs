using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace KamiSama.Extensions.Xml.Tests
{
	[TestClass]
	public class AutoXmlArrayItemAttributeTests
	{
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void VisitType_throws_InvalidOperationExcetpion()
		{
			var attr = new AutoXmlArrayItemAttribute();

			attr.VisitType(default, default, default);
		}
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]

		public void VisitProperty_throws_InvalidOperationException_if_PropertyType_is_not_an_array()
		{
			var property = typeof(Wrapper1).GetProperty(nameof(Wrapper1.SomeProperty));
			var overrides = new XmlAttributeOverrides();
			var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

			var attr = new AutoXmlArrayItemAttribute();

			attr.VisitProperty(property, overrides, allTypes);
		}
		[TestMethod]
		public void VisitProperty_does_nothing_if_no_compativle_type_is_found()
		{
			var property = typeof(ExampleClass).GetProperty(nameof(ExampleClass.SomeArrayProperty1));
			var overrides = new XmlAttributeOverrides();
			var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

			var attr = new AutoXmlArrayItemAttribute();

			attr.VisitProperty(property, overrides, allTypes);

			Assert.IsNull(overrides[property.DeclaringType, property.Name]);
		}
		[TestMethod]
		public void VisitProperty_adds_override_for_DerivedClass1_and_DerivedClass2()
		{
			var allTypes = new[] { typeof(DerivedClass1), typeof(DerivedClass2) };
			var property = typeof(ExampleClass).GetProperty(nameof(ExampleClass.SomeArrayProperty1));
			var overrides = new XmlAttributeOverrides();

			var attr = new AutoXmlArrayItemAttribute();

			attr.VisitProperty(property, overrides, allTypes);

			var elements = overrides[property.DeclaringType, property.Name].XmlArrayItems.OfType<XmlArrayItemAttribute>().ToArray();

			Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass1)));
			Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass2)));
		}
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]

		public void VisitField_throws_InvalidOperationException_if_FieldType_is_not_an_array()
		{
			var field = typeof(Wrapper2).GetField(nameof(Wrapper2.SomeField));
			var overrides = new XmlAttributeOverrides();
			var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

			var attr = new AutoXmlArrayItemAttribute();

			attr.VisitField(field, overrides, allTypes);
		}
		[TestMethod]
		public void VisitField_does_nothing_if_no_compativle_type_is_found()
		{
			var field = typeof(ExampleClass).GetField(nameof(ExampleClass.SomeArrayField1));
			var overrides = new XmlAttributeOverrides();
			var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

			var attr = new AutoXmlArrayItemAttribute();

			attr.VisitField(field, overrides, allTypes);

			Assert.IsNull(overrides[field.DeclaringType, field.Name]);
		}
		[TestMethod]
		public void VisitField_adds_override_for_DerivedClass1_and_DerivedClass2()
		{
			var allTypes = new[] { typeof(DerivedClass1), typeof(DerivedClass2) };
			var field = typeof(ExampleClass).GetField(nameof(ExampleClass.SomeArrayField1));
			var overrides = new XmlAttributeOverrides();

			var attr = new AutoXmlArrayItemAttribute();

			attr.VisitField(field, overrides, allTypes);

			var elements = overrides[field.DeclaringType, field.Name].XmlArrayItems.OfType<XmlArrayItemAttribute>().ToArray();

			Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass1)));
			Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass2)));
		}
	}
}
