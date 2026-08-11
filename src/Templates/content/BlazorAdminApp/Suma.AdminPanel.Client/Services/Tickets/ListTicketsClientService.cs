using Suma.AdminPanel.Services.Tickets;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.Paging;
using Polareum.Commons.RestSharp;

namespace Suma.AdminPanel.Client.Services.Tickets;

[AutoInjectScoped<IListTickets>]
public class ListTicketsClientService(IRestBuilder restBuilder) : IListTickets
{
	public Task<PagedResult<TicketListItemDto>> ListAsync(TicketSearchModel searchModel, CancellationToken cancellationToken)
		=> restBuilder
			.ForServiceUrl("api/tickets", "")
			.AddQueryParameter(searchModel)
			.GetAsync<PagedResult<TicketListItemDto>>(cancellationToken);
}

