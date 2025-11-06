namespace KamiSama.Extensions.Xml.Tests;

[TestClass]
public class AutoXmlElementAttributeTests
{
	[TestMethod]
	public void VisitType_throws_InvalidOperationException()
	{
		var attr = new AutoXmlElementAttribute();

		Assert.ThrowsExactly<InvalidOperationException>(() => attr.VisitType(default, default, default));
	}
	[TestMethod]
	public void VisitProperty_does_nothing_if_no_compatible_type_is_found()
	{
		var property = typeof(Wrapper1).GetProperty(nameof(Wrapper1.SomeProperty))!;
		var overrides = new XmlAttributeOverrides();
		var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

		var attr = new AutoXmlElementAttribute();

		attr.VisitProperty(property, overrides, allTypes);

		Assert.IsNull(overrides[property.DeclaringType!, property.Name]);
	}
	[TestMethod]
	public void VisitProperty_adds_override_for_DerivedClass1_and_DerivedClass2()
	{
		var allTypes = new[] { typeof(DerivedClass1), typeof(DerivedClass2) };
		var property = typeof(Wrapper1).GetProperty(nameof(Wrapper1.SomeProperty))!;
		var overrides = new XmlAttributeOverrides();

		var attr = new AutoXmlElementAttribute();

		attr.VisitProperty(property, overrides, allTypes);

		var elements = overrides[property.DeclaringType!, property.Name]!.XmlElements.OfType<XmlElementAttribute>().ToArray();

		Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass1)));
		Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass2)));
	}
	[TestMethod]
	public void VisitField_does_nothing_if_no_compatible_type_is_found()
	{
		var field = typeof(Wrapper2).GetField(nameof(Wrapper2.SomeField))!;
		var overrides = new XmlAttributeOverrides();
		var allTypes = new[] { typeof(int), typeof(double) };//some irrelevant types

		var attr = new AutoXmlElementAttribute();

		attr.VisitField(field, overrides, allTypes);

		Assert.IsNull(overrides[field.DeclaringType!, field.Name]);
	}
	[TestMethod]
	public void VisitField_adds_override_for_DerivedClass1_and_DerivedClass2()
	{
		var allTypes = new[] { typeof(DerivedClass1), typeof(DerivedClass2) };
		var field = typeof(Wrapper2).GetField(nameof(Wrapper2.SomeField))!;
		var overrides = new XmlAttributeOverrides();

		var attr = new AutoXmlElementAttribute();

		attr.VisitField(field, overrides, allTypes);

		var elements = overrides[field.DeclaringType!, field.Name]!.XmlElements.OfType<XmlElementAttribute>().ToArray();

		Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass1)));
		Assert.IsTrue(elements.Any(x => x.Type == typeof(DerivedClass2)));
	}
}
