using KamiSama.Extensions.DependencyInjection;
using Suma.AdminPanel.Services.Tickets;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Tickets;

[AutoInjectScoped<IAnswerTicket>]
public class AnswerTicketClientService(HttpClient httpClient) : IAnswerTicket
{
	public async Task<TicketDto> AnswerAsync(Guid ticketId, AnswerTicketRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsJsonAsync($"api/tickets/{ticketId}/answer", request, cancellationToken);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<TicketDto>(cancellationToken)
			?? throw new InvalidOperationException("No response returned from ticket answer endpoint.");
	}
}
