using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KamiSama.Extenders;

namespace Test.Ks.Extenders
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	[TestCategory("KS.Extenders.Stack")]
	public class StackTests
	{
		[TestMethod]
		public void TestEmptyStack()
		{
			var stack = new Stack<int>();

			Assert.AreEqual(-1, stack.PopOrDefault(-1));
			Assert.AreEqual(0, stack.PopOrDefault());
		}
		[TestMethod]
		public void TestNonEmptyStack()
		{
			var stack = new Stack<int>();

			stack.Push(10);
			stack.Push(11);

			Assert.AreEqual(11, stack.PopOrDefault());
			Assert.AreEqual(10, stack.PopOrDefault());
			Assert.AreEqual(-1, stack.PopOrDefault(-1));
		}
	}
}
