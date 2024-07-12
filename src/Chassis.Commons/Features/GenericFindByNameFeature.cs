namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IFindByNameFeature{TEntityDto}"/>
/// </summary>
public abstract class GenericFindByNameFeature<TRepository, TEntity, TEntityDto>(TRepository repository, IMapper mapper) : IFindByNameFeature<TEntityDto>
	where TRepository : IFindByNameRepository<TEntity>
{
	/// <inheritdoc />
	public async Task<TEntityDto?> FindByNameAsync(string name, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByNameAsync(name, cancellationToken) ?? throw new NotFoundException<TEntity>(name);

		return mapper.Map<TEntityDto>(entity);
	}
}
