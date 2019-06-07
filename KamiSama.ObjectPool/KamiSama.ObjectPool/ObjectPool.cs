using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace KamiSama.ObjectPool
{
	public class ObjectPool<_ObjectType> : IObjectPool<_ObjectType>
	{
		private readonly List<PooledObject<_ObjectType>> avaialbeItems;
		private readonly HashSet<PooledObject<_ObjectType>> inUseItems;
		private readonly ObjectPoolPolicy<_ObjectType> policy;

		public ObjectPool(ObjectPoolPolicy<_ObjectType> policy)
		{
			if (policy == null)
				throw new NullReferenceException($"Policy cannot be null.");

			this.policy = policy;
			this.avaialbeItems = new List<PooledObject<_ObjectType>>();
			this.inUseItems = new HashSet<PooledObject<_ObjectType>>();
		}

		public _ObjectType Get(TimeSpan waitTime)
		{
			DateTime start = DateTime.Now;

			while (avaialbeItems.Count > 0)
				lock(this)
				{
					if (avaialbeItems.Count == 0)
						break;

					var item = avaialbeItems[0];
					avaialbeItems.RemoveAt(0);

					if (policy.LifeSpan.HasValue && (DateTime.Now - item.LastAccessTime > policy.LifeSpan.Value))
						item.SafeDispose();
					else
					{
						item.LastAccessTime = DateTime.Now;
						inUseItems.Add(item);

						return item.Object;
					}
				}

			while((waitTime == TimeSpan.Zero) || (DateTime.Now - start < waitTime))
			{
				lock(this)
				{
					if (avaialbeItems.Count > 0)
					{
						var item = avaialbeItems[0];
						avaialbeItems.RemoveAt(0);

						if (policy.LifeSpan.HasValue && (DateTime.Now - item.LastAccessTime > policy.LifeSpan.Value))
							item.SafeDispose();
						else
						{
							item.LastAccessTime = DateTime.Now;
							inUseItems.Add(item);

							return item.Object;
						}
					}

					var total = avaialbeItems.Count + inUseItems.Count;

					if (!policy.MaximumAvailableInstances.HasValue || (total  < policy.MaximumAvailableInstances.Value))
					{
						var item = new PooledObject<_ObjectType>
						{
							CreateTime = DateTime.Now,
							LastAccessTime = DateTime.Now,
							Object = policy.CreateFunc()
						};
						inUseItems.Add(item);
						return item.Object;
					}
				}

				Thread.Sleep(policy.BusyWaitingInterval);
			}

			throw new TimeoutException($"Get new instance is timed out. No new item can be created.");
		}

		public void MarkAsDead(_ObjectType obj)
		{
			PooledObject<_ObjectType> item;
			lock(this)
			{
				item = inUseItems.FirstOrDefault(x => object.ReferenceEquals(x.Object, obj));

				if (item != null)
					inUseItems.Remove(item);
				else
				{
					item = avaialbeItems.FirstOrDefault(x => object.ReferenceEquals(x.Object, obj));

					if (item != null)
						avaialbeItems.Remove(item);
				}
			}

			item.SafeDispose();
		}

		public void Return(_ObjectType obj)
		{
			lock(this)
			{
				var item = inUseItems.FirstOrDefault(x => object.ReferenceEquals(x.Object, obj));

				if (item == null)
					return;

				inUseItems.Remove(item);
				avaialbeItems.Add(item);
			}
		}

		public void Dispose()
		{
			var all = avaialbeItems.Union(inUseItems).ToArray();

			avaialbeItems.Clear();
			inUseItems.Clear();

			foreach (var item in all)
				item.SafeDispose();
		}
	}
}