using Suma.AdminPanel.Services.Tickets;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Tickets;

[AutoInjectScoped<IFindTicketById>]
public class FindTicketByIdClientService(HttpClient httpClient) : IFindTicketById
{
	public async Task<TicketDto> FindByIdAsync(Guid ticketId, CancellationToken cancellationToken)
		=> await httpClient.GetFromJsonAsync<TicketDto>($"api/tickets/{ticketId}", cancellationToken)
			?? throw new InvalidOperationException("No response returned from tickets endpoint.");
}

