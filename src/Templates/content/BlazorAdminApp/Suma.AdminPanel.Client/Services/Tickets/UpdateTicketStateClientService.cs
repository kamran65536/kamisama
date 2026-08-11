using Suma.AdminPanel.Services.Tickets;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Tickets;

[AutoInjectScoped<IUpdateTicketState>]
public class UpdateTicketStateClientService(HttpClient httpClient) : IUpdateTicketState
{
	public async Task UpdateAsync(Guid ticketId, UpdateTicketStateRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PutAsJsonAsync($"api/tickets/{ticketId}/state", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}

