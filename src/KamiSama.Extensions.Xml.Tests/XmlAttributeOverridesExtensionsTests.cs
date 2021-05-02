using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace KamiSama.Extensions.Xml.Tests
{
	[TestClass]
	public class XmlAttributeOverridesExtensionsTests
	{
		[TestMethod]
		[SuppressMessage("Style", "IDE0034:Simplify 'default' expression", Justification = "<Pending>")]
		public void AddAutoAttributes_does_nothing_if_no_type_or_assembly_is_available()
		{
			var parentRoot = typeof(ParentRoot);

			var overrides = new XmlAttributeOverrides();

			overrides.AddAutoXmlAttributes(parentRoot, default(Assembly[]));

			Assert.IsNull(overrides[parentRoot]);

			foreach (var member in parentRoot.GetMembers())
				Assert.IsNull(overrides[parentRoot, member.Name]);
		}
		private static bool CollectionHas<TItem>(ICollection collection, Func<TItem, bool> predicate)
		{
			return collection.OfType<TItem>().Any(predicate);
		}
		[TestMethod]
		public void AddAutoAttributes_adds_overrides_for_AutoXmlElementAttributes()
		{
			var parentRoot = typeof(ParentRoot);
			var exampleRoot = typeof(ExampleClass);
			var wrapper1 = typeof(Wrapper1);
			var wrapper2 = typeof(Wrapper2);
			var wrapper3 = typeof(Wrapper3);
			var wrapper4 = typeof(Wrapper4);

			var overrides = new XmlAttributeOverrides();

			overrides.AddAutoXmlAttributes(parentRoot, exampleRoot.Assembly);			
			
			var someProperty_elements = overrides[wrapper1, nameof(Wrapper1.SomeProperty)].XmlElements;
			
			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someProperty_elements, e => e.Type == typeof(DerivedClass1)));
			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someProperty_elements, e => e.Type == typeof(DerivedClass2)));

			var someField_elements = overrides[wrapper2, nameof(Wrapper2.SomeField)].XmlElements;
			
			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someField_elements, e => e.Type == typeof(DerivedClass1)));
			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someField_elements, e => e.Type == typeof(DerivedClass2)));

			var someArrayProperty_arrayItems = overrides[exampleRoot, nameof(ExampleClass.SomeArrayProperty1)].XmlArrayItems;

			Assert.IsTrue(CollectionHas<XmlArrayItemAttribute>(someArrayProperty_arrayItems, e => e.Type == typeof(DerivedClass1)));
			Assert.IsTrue(CollectionHas<XmlArrayItemAttribute>(someArrayProperty_arrayItems, e => e.Type == typeof(DerivedClass2)));

			var someArrayProperty_elements = overrides[wrapper3, nameof(Wrapper3.SomeArrayProperty2)].XmlElements;

			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someArrayProperty_elements, e => e.Type == typeof(DerivedClass1)));
			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someArrayProperty_elements, e => e.Type == typeof(DerivedClass2)));
			
			var someArrayField_arrayItems = overrides[exampleRoot, nameof(ExampleClass.SomeArrayField1)].XmlArrayItems;

			Assert.IsTrue(CollectionHas<XmlArrayItemAttribute>(someArrayField_arrayItems, e => e.Type == typeof(DerivedClass1)));
			Assert.IsTrue(CollectionHas<XmlArrayItemAttribute>(someArrayField_arrayItems, e => e.Type == typeof(DerivedClass2)));

			var someArrayField_elements = overrides[wrapper4, nameof(Wrapper4.SomeArrayField2)].XmlElements;

			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someArrayField_elements, e => e.Type == typeof(DerivedClass1)));
			Assert.IsTrue(CollectionHas<XmlElementAttribute>(someArrayField_elements, e => e.Type == typeof(DerivedClass2)));
		}
		[TestMethod]
		public void SerializeAndDeserialize_should_be_successful()
		{
			var parentRoot = typeof(ParentRoot);
			var exampleRoot = typeof(ExampleClass);

			var overrides = new XmlAttributeOverrides();

			overrides.AddAutoXmlAttributes(parentRoot, exampleRoot.Assembly);
			
			var serializer = new XmlSerializer(parentRoot, overrides);

			var item = new ParentRoot
			{
				ExampleRoot = new ExampleClass
				{
					SomeArrayField1 = new AbstractClass[]
					{
						new DerivedClass1 { X = 10 },
						new DerivedClass2 { Str = "abc-f1" }
					},
					Wrapper4 = new Wrapper4
					{
						SomeArrayField2 = new AbstractClass[]
						{
							new DerivedClass1 { X = 10 },
							new DerivedClass2 { Str = "abc-f2" }
						}
					},
					SomeArrayProperty1 = new AbstractClass[]
					{
						new DerivedClass1 { X = 11 },
						new DerivedClass2 { Str = "abc-p1" }
					},
					Wrapper3 = new Wrapper3
					{
						SomeArrayProperty2 = new AbstractClass[]
						{
							new DerivedClass1 { X = 11 },
							new DerivedClass2 { Str = "abc-p2" }
						}
					},
					Wrapper1 = new Wrapper1 { SomeProperty = new DerivedClass2 { Str = "13" } },
					Wrapper2 = new Wrapper2 { SomeField = new DerivedClass1 { X = 12 } },
				},
				F = 10,
				P = 11
			};

			var str = item.SerializeToXml(options => options.Indent = true, serializer);

			var deserializedItem = str.DeserializeFromXml<ParentRoot>(serializer);
			
			Assert.AreEqual(item, deserializedItem);
		}
	}
}
