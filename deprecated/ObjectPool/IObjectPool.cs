using System;

namespace KamiSama.ObjectPool
{
	/// <summary>
	/// Object Pool interface
	/// </summary>
	/// <typeparam name="TObject"></typeparam>
	public interface IObjectPool<TObject> : IDisposable
	{
		/// <summary>
		/// returns a pooled item, if no available item is available new item will be created
		/// </summary>
		/// <param name="waitTime">maximum time to wait </param>
		/// <returns></returns>
		TObject Get(TimeSpan waitTime);
		void MarkAsDead(TObject obj);
		void Return(TObject obj);
	}
}
