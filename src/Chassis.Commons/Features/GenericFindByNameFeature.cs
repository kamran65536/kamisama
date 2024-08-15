namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IFindByNameFeature{TEntityDto}"/>
/// </summary>
public abstract class GenericFindByNameFeature<TEntity, TEntityDto, TRepository>(TRepository repository, IMapper mapper) : 
	IFindByNameFeature<TEntityDto>
	where TRepository : ILookupByNameRepository<TEntity>
{
	/// <inheritdoc />
	public async virtual Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByNameAsync(name, cancellationToken) ?? throw new NotFoundException<TEntity>(name);

		return mapper.Map<TEntityDto>(entity);
	}
}
