using System.Collections.Generic;

namespace KamiSama.Extensions
{
	public static class QueueExtensions
    {
		public static T DequeueOrDefault<T>(this Queue<T> queue, T defaultValue = default(T))
		{
			if (queue.Count == 0)
				return defaultValue;
			else
				return queue.Dequeue();
		}
    }
}
