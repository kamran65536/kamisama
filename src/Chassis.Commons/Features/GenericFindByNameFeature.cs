namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IFindByNameFeature{TEntityDto}"/>
/// </summary>
public abstract class GenericFindByNameFeature<TEntity, TEntityDto, TRepository>(TRepository repository) : 
	IFindByNameFeature<TEntityDto>
	where TRepository : ILookupByNameRepository<TEntity>
{
	/// <summary>
	/// Repository field to be used
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Converts the entity to dto
	/// </summary>
	protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);

	/// <inheritdoc />
	public async virtual Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByNameAsync(name, cancellationToken) ?? throw new NotFoundException<TEntity>(name);

		return await ConvertToDto(entity, cancellationToken);
	}
}
