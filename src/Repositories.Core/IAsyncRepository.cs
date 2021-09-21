using System;
using System.Linq.Expressions;
using System.Threading;
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
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task AddAsync(_EntityType item, CancellationToken cancellationToken = default);
		/// <summary>
		/// Updates an item in the repository
		/// </summary>
		/// <param name="item"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task UpdateAsync(_EntityType item, CancellationToken cancellationToken = default);
		/// <summary>
		/// Deletes an item from repository
		/// </summary>
		/// <param name="item"></param>
		/// <param name="cancellation"></param>
		/// <returns></returns>
		Task DeleteAsync(_EntityType item, CancellationToken cancellation = default);
		/// <summary>
		/// Finds an item in the repository
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task<_EntityType> FindAsync(Expression<Func<_EntityType, bool>> predicate, CancellationToken cancellationToken = default);
	}
}
