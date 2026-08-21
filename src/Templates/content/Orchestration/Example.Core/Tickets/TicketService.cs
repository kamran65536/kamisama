using Example.Abstractions;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules.Ticketing.Features.Tickets;

namespace Example.Core.Tickets;

[AutoInjectScoped<IListAdminTickets>]
public sealed class TicketService(IListTickets tickets) : IListAdminTickets
{
    public async Task<IReadOnlyList<TicketSummary>> ListAsync(CancellationToken cancellationToken = default)
    {
        var result = await tickets.ListAsync(new TicketSearchModel(1, 100, null, null, null, null, null, null), cancellationToken);
        return result.Items.Select(ticket => new TicketSummary(ticket.Id, ticket.Title, ticket.Status.ToString())).ToArray();
    }
}
