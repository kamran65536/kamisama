using KamiSama.Modules.PolicyEngine.Features.PolicyActions;

namespace KamiSama.Modules.PolicyEngine.Repositories.Implementations;

[AutoInjectScoped<IPolicyActionRepository>]
internal class PolicyActionRepository(PolicyEngineDbContext context) :
	GenericRepository<PolicyAction, PolicyActionSearchModel, PolicyEngineDbContext>(context),
	IPolicyActionRepository
{
	protected override IQueryable<PolicyAction> ApplySearchModel(IQueryable<PolicyAction> query, PolicyActionSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
			query = query.Where(x => x.Name.ToLower() == searchModel.Name.ToLower());
		if (!string.IsNullOrWhiteSpace(searchModel.HandlerName))
			query = query.Where(x => x.HandlerName.ToLower() == searchModel.HandlerName.ToLower());
		if (searchModel.IsEnabled.HasValue)
			query = query.Where(x => x.IsEnabled == searchModel.IsEnabled.Value);

		return searchModel.OrderBy?.ToLower() switch
		{
			"id" => query.OrderBy(x => x.Id),
			"name" => query.OrderBy(x => x.Name),
			"handlername" => query.OrderBy(x => x.HandlerName),
			"createdat" => query.OrderBy(x => x.CreatedAt),
			"updatedat" => query.OrderBy(x => x.UpdatedAt),
			_ => query.OrderBy(x => x.Name),
		};
	}

	public Task<PolicyAction?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> FindAsync(x => x.Id == id, cancellationToken);
	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Id == id, cancellationToken);
	public Task<PolicyAction?> FindByNameAsync(string name, CancellationToken cancellationToken)
		=> FindAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
}
