using TicketingFeatures = KamiSama.Modules.Ticketing.Features.Tickets;

namespace Suma.AdminPanel.Services.Tickets;

[AutoInjectScoped<IListTickets>]
internal class ListTickets(
	ILogger<ListTickets> logger,
	TicketingFeatures.IListTickets listTickets) : IListTickets
{
	public async Task<PagedResult<TicketListItemDto>> ListAsync(TicketSearchModel searchModel, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();
		var result = await listTickets.ListAsync(searchModel.ToTicketingSearchModel(), cancellationToken);
		var filteredItems = FilterAndOrder(result.Items, searchModel).ToList();
		var totalCount = filteredItems.Count;
		var pageItems = Page(filteredItems, searchModel);

		return new PagedResult<TicketListItemDto>(totalCount, [.. pageItems.Select(x => x.ToListItemDto())]);
	}

	private static IEnumerable<TicketingFeatures.TicketListItemDto> FilterAndOrder(IEnumerable<TicketingFeatures.TicketListItemDto> items, TicketSearchModel searchModel)
	{
		var query = items;
		if (!string.IsNullOrWhiteSpace(searchModel.Id))
		{
			query = Guid.TryParse(searchModel.Id, out var id)
				? query.Where(x => x.Id == id)
				: query.Where(x => x.Id.ToString().Contains(searchModel.Id, StringComparison.OrdinalIgnoreCase));
		}
		if (!string.IsNullOrWhiteSpace(searchModel.Title))
			query = query.Where(x => string.Equals(x.Title, searchModel.Title, StringComparison.OrdinalIgnoreCase));
		if (searchModel.From is not null)
			query = query.Where(x => x.CreatedAt >= searchModel.From.Value);
		if (searchModel.To is not null)
			query = query.Where(x => x.CreatedAt <= searchModel.To.Value);

		return searchModel.OrderBy?.ToLowerInvariant() switch
		{
			"datetime" or "createdat" => query.OrderByDescending(x => x.CreatedAt),
			"subject" or "title" => query.OrderBy(x => x.Title),
			"status" => query.OrderBy(x => x.Status),
			"priority" => query.OrderBy(x => x.Priority),
			_ => query,
		};
	}

	private static IReadOnlyList<TicketingFeatures.TicketListItemDto> Page(IReadOnlyList<TicketingFeatures.TicketListItemDto> items, TicketSearchModel searchModel)
	{
		if (searchModel.Page <= 0 || searchModel.PageSize <= 0)
			return items;

		return [.. items.Skip((searchModel.Page - 1) * searchModel.PageSize).Take(searchModel.PageSize)];
	}
}

