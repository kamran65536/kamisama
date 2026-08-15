using KamiSama.Modules.PolicyEngine.Features.PolicyLists;

namespace KamiSama.Modules.PolicyEngine.Repositories.Implementations;

[AutoInjectScoped<IPolicyListRepository>]
internal class PolicyListRepository(PolicyEngineDbContext context) :
	GenericRepository<PolicyList, PolicyListSearchModel, PolicyEngineDbContext>(context),
	IPolicyListRepository
{
	protected override IQueryable<PolicyList> ApplySearchModel(IQueryable<PolicyList> query, PolicyListSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
			query = query.Where(x => x.Name.ToLower() == searchModel.Name.ToLower());
		if (searchModel.Type.HasValue)
			query = query.Where(x => x.Type == searchModel.Type.Value);
		if (searchModel.IsEnabled.HasValue)
			query = query.Where(x => x.IsEnabled == searchModel.IsEnabled.Value);

		return searchModel.OrderBy?.ToLower() switch
		{
			"id" => query.OrderBy(x => x.Id),
			"name" => query.OrderBy(x => x.Name),
			"type" => query.OrderBy(x => x.Type),
			"createdat" => query.OrderBy(x => x.CreatedAt),
			"updatedat" => query.OrderBy(x => x.UpdatedAt),
			_ => query.OrderBy(x => x.Name),
		};
	}

	public Task<PolicyList?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> FindAsync(x => x.Id == id, cancellationToken);
	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Id == id, cancellationToken);
	public Task<PolicyList?> FindByNameAsync(string name, CancellationToken cancellationToken)
		=> FindAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
}
