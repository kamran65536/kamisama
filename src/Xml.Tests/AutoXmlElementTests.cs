namespace KamiSama.Extensions.Xml.Tests;

[TestClass]
public class AutoXmlElementTests
{
	[TestMethod]
	public void Implicit_operator_creates_a_new_AutoXmlElement()
	{
		object o = new();

		AutoXmlElement<object> a = o;

		Assert.IsNotNull(a);
		Assert.AreSame(a.Value, o);
	}
	[TestMethod]
	public void Eqials_returns_false_if_other_is_null()
	{
		var element = new AutoXmlElement<object>();

		Assert.IsFalse(element.Equals(null));
	}
}
