using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KamiSama.Chassis.Commons.Features;



/// <summary>
/// Binds the types shared by a CRUD feature set and exposes nested bases for common operations.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
/// <typeparam name="TEntityDto">The DTO returned by query and create features.</typeparam>
/// <typeparam name="TAddRequest">The create request type.</typeparam>
/// <typeparam name="TUpdateRequest">The update request type.</typeparam>
/// <typeparam name="TRepository">The repository shared by the feature set.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
/// <typeparam name="TKey">The entity key type.</typeparam>
public class FeatureDefinitionBase<TEntity, TEntityDto, TAddRequest, TUpdateRequest, TRepository, TSearchModel, TKey>
	where TSearchModel : SearchModel
	where TRepository : IGenericRepository<TEntity, TSearchModel>, ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// Provides the standard paged-list workflow for the bound feature types.
	/// </summary>
	/// <param name="repository">The repository used to load entities.</param>
	public abstract class ListFeatureBase(TRepository repository) : GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(repository);
	/// <summary>
	/// Provides the standard create workflow for the bound feature types.
	/// </summary>
	/// <param name="repository">The repository used to add entities.</param>
	public abstract class AddFeatureBase(TRepository repository) : GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(repository);
	/// <summary>
	/// Provides the standard update workflow for the bound feature types.
	/// </summary>
	/// <param name="repository">The repository used to find and update entities.</param>
	public abstract class UpdateFeatureBase(TRepository repository) : GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(repository);
	/// <summary>
	/// Provides the standard delete workflow for the bound feature types.
	/// </summary>
	/// <param name="repository">The repository used to find and delete entities.</param>
	public abstract class DeleteFeatureBase(TRepository repository) :  GenericDeleteFeature<TEntity, TRepository, TKey>(repository);
	/// <summary>
	/// Provides the standard find-by-identifier workflow for the bound feature types.
	/// </summary>
	/// <param name="repository">The repository used to find entities.</param>
	public abstract class FindByIdFeatureBase(TRepository repository) : GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(repository);
	/// <summary>
	/// Provides the standard exists-by-identifier workflow for the bound feature types.
	/// </summary>
	/// <param name="repository">The repository used for existence checks.</param>
	public abstract class ExistsByIdFeatureBase(TRepository repository) : GenericExistsByIdFeature<TEntity, TRepository, TKey>(repository);
}
