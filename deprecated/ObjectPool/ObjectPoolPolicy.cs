using System;

namespace KamiSama.ObjectPool
{
	public class ObjectPoolPolicy<_ObjectType>
	{
		public TimeSpan? LifeSpan { get; set; }
		public int? MaximumAvailableInstances { get; set; }
		public Func<_ObjectType> CreateFunc { get; set; }
		public TimeSpan BusyWaitingInterval { get; set; } = TimeSpan.FromMilliseconds(20);
	}
}
