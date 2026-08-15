using System;
using System.Linq.Expressions;

namespace KamiSama.Repositories
{
	/// <summary>
	/// Defines synchronous mutation and single-item lookup operations for a repository.
	/// </summary>
	/// <typeparam name="TEntity">The entity type stored by the repository.</typeparam>
	public interface IRepository<TEntity> : IDisposable
    {
		/// <summary>
		/// Adds an entity according to the implementation's persistence and duplicate rules.
		/// </summary>
		/// <param name="item">The entity to add.</param>
		void Add(TEntity item);
		/// <summary>
		/// Updates an entity according to the implementation's persistence rules.
		/// </summary>
		/// <param name="item">The entity to update.</param>
		void Update(TEntity item);
		/// <summary>
		/// Deletes an entity according to the implementation's matching and persistence rules.
		/// </summary>
		/// <param name="item">The entity to delete.</param>
		void Delete(TEntity item);
		/// <summary>
		/// Returns the first entity that satisfies the predicate, or <see langword="null"/> when none matches.
		/// </summary>
		/// <param name="predicate">The predicate used to select an entity.</param>
		/// <returns>The first matching entity, or <see langword="null"/>.</returns>
		TEntity? Find(Expression<Func<TEntity, bool>> predicate);
    }
}
