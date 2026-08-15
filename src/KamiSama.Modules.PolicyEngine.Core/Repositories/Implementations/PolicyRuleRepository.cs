using KamiSama.Modules.PolicyEngine.Features.PolicyRules;

namespace KamiSama.Modules.PolicyEngine.Repositories.Implementations;

[AutoInjectScoped<IPolicyRuleRepository>]
internal class PolicyRuleRepository(PolicyEngineDbContext context) :
	GenericRepository<PolicyRule, PolicyRuleSearchModel, PolicyEngineDbContext>(context),
	IPolicyRuleRepository
{
	protected override IQueryable<PolicyRule> ApplySearchModel(IQueryable<PolicyRule> query, PolicyRuleSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
			query = query.Where(x => x.Name.ToLower() == searchModel.Name.ToLower());
		if (searchModel.IsEnabled.HasValue)
			query = query.Where(x => x.IsEnabled == searchModel.IsEnabled.Value);

		return searchModel.OrderBy?.ToLower() switch
		{
			"id" => query.OrderBy(x => x.Id),
			"name" => query.OrderBy(x => x.Name),
			"processorder" => query.OrderBy(x => x.ProcessOrder),
			"createdat" => query.OrderBy(x => x.CreatedAt),
			"updatedat" => query.OrderBy(x => x.UpdatedAt),
			_ => query.OrderBy(x => x.ProcessOrder),
		};
	}

	public Task<PolicyRule?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> FindAsync(x => x.Id == id, cancellationToken);
	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Id == id, cancellationToken);
	public Task<PolicyRule?> FindByNameAsync(string name, CancellationToken cancellationToken)
		=> FindAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
}
