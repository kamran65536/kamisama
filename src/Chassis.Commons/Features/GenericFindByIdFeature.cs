namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IFindByIdFeature{TEntityDto, TKey}"/>
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TEntityDto"></typeparam>
/// <typeparam name="TRepository"></typeparam>
/// <typeparam name="TKey"></typeparam>
/// <param name="repository"></param>
/// <param name="mapper"></param>
public abstract class GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(TRepository repository, IMapper mapper) :
	IFindByIdFeature<TEntityDto, TKey>
	where TRepository : IFindByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// converts an item, the default behaviour uses <see cref="IMapper"/>
	/// </summary>
	/// <param name="entity"></param>
	/// <returns></returns>
	protected virtual TEntityDto ConvertToDto(TEntity entity)
		=> mapper.Map<TEntityDto>(entity);

	/// <summary>
	/// Finds an 
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="NotFoundException"></exception>
	public async Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException<TEntity>(id);

		return ConvertToDto(entity);
	}
}
