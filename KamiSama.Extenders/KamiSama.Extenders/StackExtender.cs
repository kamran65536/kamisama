using System.Collections.Generic;

namespace KamiSama.Extenders
{
	public static class StackExtender
    {
		public static T PopOrDefault<T>(this Stack<T> stack, T defaultValue = default(T))
		{
			if (stack.Count == 0)
				return defaultValue;
			else
				return stack.Pop();
		}
    }
}
