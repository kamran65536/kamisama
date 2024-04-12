namespace KamiSama.Extensions.Core.Tests;

[TestClass]
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
