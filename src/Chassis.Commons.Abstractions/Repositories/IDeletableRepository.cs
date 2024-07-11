namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Repository with Delete feature
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IDeletableRepository<TEntity>
{
	/// <summary>
	/// Deletes an item from the database
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}
