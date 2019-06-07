using System;

namespace KamiSama.ObjectPool
{
	public class PooledObject<_ObjectType>
	{
		public DateTime CreateTime { get; set; }
		public DateTime LastAccessTime { get; set; }
		public _ObjectType Object { get; set; }

		internal void SafeDispose()
		{
			if (Object is IDisposable disposable)
				try
				{
					disposable.Dispose();
				}
				catch 
				{
				}

			Object = default;
		}
	}
}
