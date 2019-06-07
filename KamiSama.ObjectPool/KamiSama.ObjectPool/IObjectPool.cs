using System;

namespace KamiSama.ObjectPool
{
	/// <summary>
	/// Object Pool interface
	/// </summary>
	/// <typeparam name="_ObjectType"></typeparam>
	public interface IObjectPool<_ObjectType> : IDisposable
	{
		/// <summary>
		/// returns a pooled item, if no available item is available new item will be created
		/// </summary>
		/// <param name="waitTime">maximum time to wait </param>
		/// <returns></returns>
		_ObjectType Get(TimeSpan waitTime);
		void MarkAsDead(_ObjectType obj);
		void Return(_ObjectType obj);
	}
}
