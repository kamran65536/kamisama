namespace KamiSama.Extensions.Xml.Tests;

public class Wrapper1
{
	[AutoXmlElement]
	public AbstractClass SomeProperty { get; set; }
}
public class Wrapper2
{
	[AutoXmlElement]
	public AbstractClass SomeField;
}
public class Wrapper3
{
	[AutoXmlElement]
	public AbstractClass[] SomeArrayProperty2 { get; set; }
}
public class Wrapper4
{
	[AutoXmlElement]
	public AbstractClass[] SomeArrayField2;
}
public class ExampleClass : IEquatable<ExampleClass>
{
	public Wrapper1 Wrapper1 { get; set; }
	public Wrapper2 Wrapper2 { get; set; }
	public Wrapper3 Wrapper3 { get; set; }
	public Wrapper4 Wrapper4 { get; set; }
	[AutoXmlArrayItem]
	public AbstractClass[] SomeArrayProperty1 { get; set; }
	[AutoXmlArrayItem]
	public AbstractClass[] SomeArrayField1;
	
	public bool Equals(ExampleClass other)
	{
		return
			(other != null) &&
			Wrapper1.SomeProperty.Equals(other.Wrapper1.SomeProperty) &&
			Wrapper2.SomeField.Equals(other.Wrapper2.SomeField) &&
			ArrayUtility.ArrayEqual(SomeArrayField1, other.SomeArrayField1) &&
			ArrayUtility.ArrayEqual(Wrapper4.SomeArrayField2, other.Wrapper4.SomeArrayField2) &&
			ArrayUtility.ArrayEqual(SomeArrayProperty1, other.SomeArrayProperty1) &&
			ArrayUtility.ArrayEqual(Wrapper3.SomeArrayProperty2, other.Wrapper3.SomeArrayProperty2);
	}
	public override bool Equals(object obj) => Equals(obj as ExampleClass);

	public override int GetHashCode()
	{
		return HashCode.Combine(Wrapper1.SomeProperty, Wrapper2.SomeField, SomeArrayProperty1, Wrapper3.SomeArrayProperty2, SomeArrayField1, Wrapper4.SomeArrayField2);
	}
}
