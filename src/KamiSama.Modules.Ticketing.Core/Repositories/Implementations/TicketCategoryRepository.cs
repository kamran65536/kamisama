using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Repositories.Implementations;

[AutoInjectScoped<ITicketCategoryRepository>]
internal class TicketCategoryRepository(TicketingDbContext context) :
	GenericRepository<TicketCategory, TicketCategorySearchModel, TicketingDbContext>(context),
	ITicketCategoryRepository
{
	/// <summary>Applies case-insensitive exact-name filtering and category ordering.</summary>
	/// <param name="query">The tracked category query to shape.</param>
	/// <param name="searchModel">The requested name, paging inputs, and ordering token.</param>
	/// <returns>The filtered and ordered query used by the generic repository.</returns>
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
	/// <summary>Finds the first category with the supplied identifier.</summary>
	/// <param name="id">The category identifier.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns>The matching category, or <see langword="null"/> when absent.</returns>
	public Task<TicketCategory?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);
	/// <summary>Tests whether a category exists with the supplied identifier.</summary>
	/// <param name="id">The category identifier.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns><see langword="true"/> when a matching category exists; otherwise <see langword="false"/>.</returns>
	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);
	/// <summary>Finds the first category whose lowercased name equals the lowercased input.</summary>
	/// <param name="name">The category name.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns>The matching category, or <see langword="null"/> when absent.</returns>
	public Task<TicketCategory?> FindByNameAsync(string name, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
	/// <summary>Tests for a category using a lowercased exact-name comparison.</summary>
	/// <param name="name">The category name.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns><see langword="true"/> when a matching category exists; otherwise <see langword="false"/>.</returns>
	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
}
