using System;

namespace KamiSama.ObjectPool
{
	public static class IObjectPoolExtender
	{
		public static _ObjectType Get<_ObjectType>(this IObjectPool<_ObjectType> pool) => pool.Get(TimeSpan.Zero);
		public static _ObjectType Get<_ObjectType>(this IObjectPool<_ObjectType> pool, int waitMilliseconds) => pool.Get(TimeSpan.FromMilliseconds(waitMilliseconds));
	}
}
