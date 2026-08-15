namespace KamiSama.Extensions;

/// <summary>
/// Provides extensions for safely dequeuing a value or returning a fallback when a queue is empty.
/// Use them when an empty queue is an expected condition rather than an error.
/// </summary>
public static class QueueExtensions
{
	/// <summary>
	/// Dequeues and returns the next item, or returns the specified fallback when the queue is empty.
	/// </summary>
	/// <typeparam name="TItem"></typeparam>
	/// <param name="queue"></param>
	/// <param name="defaultValue"></param>
	/// <returns>the item or default value if queue is empty</returns>
	public static TItem? DequeueOrDefault<TItem>(this Queue<TItem> queue, TItem? defaultValue = default)
	{
		if (queue.Count == 0)
			return defaultValue;
		else
			return queue.Dequeue();
	}
}
