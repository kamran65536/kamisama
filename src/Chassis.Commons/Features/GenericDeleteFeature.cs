namespace KamiSama.Chassis.Commons.Features;
/// <summary>
/// Generic implementation of <see cref="IDeleteFeature{TKey}"/>
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TRepository"></typeparam>
/// <typeparam name="TKey"></typeparam>
/// <param name="repository"></param>
public abstract class GenericDeleteFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IDeleteFeature<TKey>
	where TRepository : IFindByIdRepository<TEntity, TKey>, IDeletableRepository<TEntity>
{
	/// <summary>
	/// Checks if the entity can be deleted or not. the default behaviour always returns true
	/// </summary>
	/// <returns></returns>
	protected virtual Task<bool> CanBeDeletedAsync(TRepository repository, TEntity entity)
		=> Task.FromResult(true);

	/// <inheritdoc />
	public async virtual Task DeleteAsync(TKey id, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(TEntity), id);

		if (await CanBeDeletedAsync(repository, entity))
			await repository.DeleteAsync(entity, cancellationToken);
	}
}
