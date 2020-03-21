using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KamiSama.Repositories
{
	/// <summary>
	/// IAsyncRepository is the same as IRepository
	/// </summary>
	/// <typeparam name="_EntityType"></typeparam>
	public interface IAsyncRepository<_EntityType> : IRepository<_EntityType>
	{
		/// <summary>
		/// Adds an item into the repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Task AddAsync(_EntityType item);
		/// <summary>
		/// Updates an item in the repositry
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Task UpdateAsync(_EntityType item);
		/// <summary>
		/// Deletes an item from repository
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Task DeleteAsync(_EntityType item);
		/// <summary>
		/// Finds an item in the repository
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		Task<_EntityType> FindAsync(Expression<Func<_EntityType, bool>> predicate);
	}
}
