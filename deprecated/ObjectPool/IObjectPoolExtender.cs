using System;

namespace KamiSama.ObjectPool
{
	public static class IObjectPoolExtender
	{
		public static TObject Get<TObject>(this IObjectPool<TObject> pool) => pool.Get(TimeSpan.Zero);
		public static TObject Get<TObject>(this IObjectPool<TObject> pool, int waitMilliseconds) => pool.Get(TimeSpan.FromMilliseconds(waitMilliseconds));
	}
}
