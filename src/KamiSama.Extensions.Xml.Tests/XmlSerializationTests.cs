using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;

namespace KamiSama.Extensions.Xml.Tests
{
	[TestClass]
	public class XmlSerializationTests
	{
		public class A
		{
			public int X { get; set; }
		}

		[TestMethod]
		public void SerializeToXml_must_serialize_object_to_Xml()
		{
			var a = new A { X = 10 };

			var result = a.SerializeToXml();

			StringAssert.Contains(result, "<A");
			StringAssert.Contains(result, "<X>10</X>");
			StringAssert.Contains(result, "</A>");
		}
		[TestMethod]
		public void SerializeToXml_must_use_custom_serializer_if_available()
		{
			var a = new A { X = 10 };

			var serializer = new XmlSerializer(typeof(A), new XmlRootAttribute { ElementName = "B", IsNullable = true });
			var result = a.SerializeToXml(serializer: serializer);

			StringAssert.Contains(result, "<B");
			StringAssert.Contains(result, "<X>10</X>");
			StringAssert.Contains(result, "</B>");
		}
		[TestMethod]
		public void SerializeToXml_must_config_actions_through_settingsAction()
		{
			var a = new A { X = 10 };
			var result = a.SerializeToXml(settings =>
			{
				settings.Indent = true;
				settings.IndentChars = "\t";
			});

			StringAssert.Contains(result, "<A");
			StringAssert.Contains(result, "\t<X>10</X>");
			StringAssert.Contains(result, "</A>");
		}
		[TestMethod]
		public void DeserializeFromXml_returns_deserialized_object()
		{
			var str = @"<A><X>10</X></A>";

			var a = str.DeserializeFromXml<A>();

			Assert.AreEqual(10, a.X);
		}
		[TestMethod]
		public void DeserializeFromXml_must_use_custom_serializer_if_available()
		{
			var str = @"<B><X>10</X></B>";

			var serializer = new XmlSerializer(typeof(A), new XmlRootAttribute { ElementName = "B" });

			var a = str.DeserializeFromXml<A>(serializer);

			Assert.AreEqual(10, a.X);
		}
	}
}
