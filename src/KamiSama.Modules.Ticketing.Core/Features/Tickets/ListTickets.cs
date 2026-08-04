namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IListTickets>]
internal class ListTickets(ITicketRepository repository) : 
    GenericListFeature<Ticket, TicketListItemDto, TicketSearchModel, ITicketRepository>(repository),
    IListTickets
{
	protected override Task<TicketListItemDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
