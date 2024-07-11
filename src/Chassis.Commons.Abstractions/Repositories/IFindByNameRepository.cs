namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Repository with find by name feature
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IFindByNameRepository<TEntity>
{
	/// <summary>
	/// Finds an item with name
	/// </summary>
	/// <param name="name"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<TEntity?> FindByNameAsync(string name, CancellationToken cancellationToken);
}
