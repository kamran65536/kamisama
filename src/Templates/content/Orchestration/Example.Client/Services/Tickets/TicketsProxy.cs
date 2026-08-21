using Example.Abstractions;
using System.Net.Http.Json;

namespace Example.Client.Services.Tickets;

public sealed class TicketsProxy(HttpClient http) : IListAdminTickets
{
    public async Task<IReadOnlyList<TicketSummary>> ListAsync(CancellationToken cancellationToken = default)
        => await http.GetFromJsonAsync<TicketSummary[]>("api/tickets", cancellationToken) ?? [];
}
