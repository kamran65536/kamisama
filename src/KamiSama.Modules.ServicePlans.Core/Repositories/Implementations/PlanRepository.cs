using KamiSama.Modules.ServicePlans.Features.Plans;

namespace KamiSama.Modules.ServicePlans.Repositories.Implementations;

[AutoInjectScoped<IPlanRepository>]
internal class PlanRepository(ServicePlansDbContext context) :
	GenericRepository<Plan, PlanSearchModel, ServicePlansDbContext>(context),
	IPlanRepository
{
	protected override IQueryable<Plan> ApplySearchModel(IQueryable<Plan> query, PlanSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
			query = query.Where(x => x.Name.ToLower() == searchModel.Name.ToLower());

		if (searchModel.PeriodType.HasValue)
			query = query.Where(x => x.PeriodType == searchModel.PeriodType.Value);

		if (searchModel.IsEnabled.HasValue)
			query = query.Where(x => x.IsEnabled == searchModel.IsEnabled.Value);

		return searchModel.OrderBy?.ToLower() switch
		{
			"id" => query.OrderBy(x => x.Id),
			"name" => query.OrderBy(x => x.Name),
			"computationunits" => query.OrderBy(x => x.ComputationUnits),
			"ratelimit" => query.OrderBy(x => x.RateLimit),
			"periodtype" => query.OrderBy(x => x.PeriodType),
			"durationindays" => query.OrderBy(x => x.DurationInDays),
			"isenabled" => query.OrderBy(x => x.IsEnabled),
			"createdat" => query.OrderBy(x => x.CreatedAt),
			"updatedat" => query.OrderBy(x => x.UpdatedAt),
			_ => query.OrderBy(x => x.Name),
		};
	}

	public Task<Plan?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Id == id, cancellationToken);

	public Task<Plan?> FindByNameAsync(string name, CancellationToken cancellationToken)
		=> FindAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);

	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
}
