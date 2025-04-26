using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KamiSama.Chassis.Commons.Features;



/// <summary>
/// This class can be used as reference for different type mapping in order to reduce the work load of using features
/// </summary>
public class FeatureDefinitionBase<TEntity, TEntityDto, TAddRequest, TUpdateRequest, TRepository, TSearchModel, TKey>
	where TSearchModel : SearchModel
	where TRepository : IGenericRepository<TEntity, TSearchModel>, ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// List Feature
	/// </summary>
	public abstract class ListFeatureBase(TRepository repository, IMapper mapper) : GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(repository, mapper);
	/// <summary>
	/// Add Feature
	/// </summary>
	public abstract class AddFeatureBase(TRepository repository, IMapper mapper) : GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(repository, mapper);
	/// <summary>
	/// Update Feature
	/// </summary>
	public abstract class UpdateFeatureBase(TRepository repository, IMapper mapper) : GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(repository, mapper);
	/// <summary>
	/// Delete Feature
	/// </summary>
	public abstract class DeleteFeatureBase(TRepository repository) :  GenericDeleteFeature<TEntity, TRepository, TKey>(repository);
	/// <summary>
	/// Find By Id Feature
	/// </summary>
	public abstract class FindByIdFeatureBase(TRepository repository, IMapper mapper) : GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(repository, mapper);
	/// <summary>
	/// Exists by Id Feature
	/// </summary>
	public abstract class ExistsByIdFeatureBase(TRepository repository) : GenericExistsByIdFeature<TEntity, TRepository, TKey>(repository);
}