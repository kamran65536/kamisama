using System;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	/// <summary>
	/// Repository interface
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IRepository<TEntity> : IDisposable
    {
		/// <summary>
		/// Adds a new item in the repository
		/// </summary>
		/// <param name="item"></param>
		void Add(TEntity item);
		/// <summary>
		/// Update method, does nothing
		/// </summary>
		/// <param name="item"></param>
		void Update(TEntity item);
		/// <summary>
		/// Deletes an item from repository
		/// </summary>
		/// <param name="item"></param>
		void Delete(TEntity item);
		/// <summary>
		/// Finds an single item in the repository
		/// </summary>
		/// <param name="predicate">the predicate to search, if null it returns null</param>
		/// <returns></returns>
		TEntity? Find(Expression<Func<TEntity, bool>>? predicate = null);
    }
}
