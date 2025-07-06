namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IFindByIdFeature{TEntityDto, TKey}"/>
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TEntityDto"></typeparam>
/// <typeparam name="TRepository"></typeparam>
/// <typeparam name="TKey"></typeparam>
/// <param name="repository"></param>
public abstract class GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(TRepository repository) :
	IFindByIdFeature<TEntityDto, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// Repository field to be used
	/// </summary>
	protected TRepository Repository { get => repository; }

	/// <summary>
	/// converts entity to dto
	/// </summary>
	protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
	/// <summary>
	/// Finds an 
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="NotFoundException"></exception>
	public async virtual Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException<TEntity>(id);

		return await ConvertToDto(entity, cancellationToken);
	}
}
