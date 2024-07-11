namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Repository with update capability
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IUpdatableRepository<TEntity>
{
	/// <summary>
	/// Updates an item in the database
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
