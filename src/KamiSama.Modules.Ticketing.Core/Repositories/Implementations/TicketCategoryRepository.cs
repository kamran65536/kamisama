using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Repositories.Implementations;

[AutoInjectScoped<ITicketCategoryRepository>]
internal class TicketCategoryRepository(TicketingDbContext context) :
	GenericRepository<TicketCategory, TicketCategorySearchModel, TicketingDbContext>(context),
	ITicketCategoryRepository
{
	protected override IQueryable<TicketCategory> ApplySearchModel(IQueryable<TicketCategory> query, TicketCategorySearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
			query = query.Where(x => x.Name.ToLower() == searchModel.Name.ToLower());


		return searchModel.OrderBy?.ToLower() switch
		{
			"id" => query.OrderBy(x => x.Id),
			"name" => query.OrderBy(x => x.Name),
			"createdat" => query.OrderBy(x => x.CreatedAt),
			"updatedat" => query.OrderBy(x => x.UpdatedAt),
			_ => query.OrderBy(x => x.Name)
		};
	}
	public Task<TicketCategory?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);
	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);
	public Task<TicketCategory?> FindByNameAsync(string name, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
}
