using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using KamiSama.Extenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks.Extenders
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	[TestCategory("KS.Extenders.Dictionary")]
	public class DictionaryTests
	{
		[TestMethod]
		public void TestAddOrUpdate()
		{
			var dictionary = new Dictionary<int, int>();

			dictionary.AddOrUpdate(10, 100);


			Assert.IsTrue(dictionary.TryGetValue(10, out int x));
			Assert.AreEqual(100, x);
			Assert.IsFalse(dictionary.TryGetValue(11, out x));

			dictionary.AddOrUpdate(11, 101);
			Assert.IsTrue(dictionary.TryGetValue(11, out x));
			Assert.AreEqual(101, x);

			dictionary.AddOrUpdate(11, 102);
			Assert.IsTrue(dictionary.TryGetValue(11, out x));
			Assert.AreEqual(102, x);
		}

	}
}
