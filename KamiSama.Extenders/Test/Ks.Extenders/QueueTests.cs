using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KamiSama.Extenders;

namespace Test.Ks.Extenders
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	[TestCategory("KS.Extenders.Queue")]
	public class QueueTests
	{
		[TestMethod]
		public void TestEmptyQueue()
		{
			var queue = new Queue<int>();

			Assert.AreEqual(-1, queue.DequeueOrDefault(-1));
			Assert.AreEqual(0, queue.DequeueOrDefault());
		}
		[TestMethod]
		public void TestNotEmptyQueue()
		{
			var queue = new Queue<int>();

			queue.Enqueue(10);
			queue.Enqueue(11);

			Assert.AreEqual(10, queue.DequeueOrDefault(-1));
			Assert.AreEqual(11, queue.DequeueOrDefault(-1));
		}
	}
}
