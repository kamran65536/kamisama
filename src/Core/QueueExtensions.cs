using System.Collections.Generic;

namespace KamiSama.Extensions
{
	/// <summary>
	/// Queue Extensions
	/// </summary>
	public static class QueueExtensions
    {
		/// <summary>
		/// Dequeues or return default value for item
		/// </summary>
		/// <typeparam name="TItem"></typeparam>
		/// <param name="queue"></param>
		/// <param name="defaultValue"></param>
		/// <returns>the item or default value if queue is empty</returns>
		public static TItem DequeueOrDefault<TItem>(this Queue<TItem> queue, TItem defaultValue = default)
		{
			if (queue.Count == 0)
				return defaultValue;
			else
				return queue.Dequeue();
		}
    }
}
