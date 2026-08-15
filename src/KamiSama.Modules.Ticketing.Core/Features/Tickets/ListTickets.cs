namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IListTickets>]
internal class ListTickets(ITicketRepository repository) : 
    GenericListFeature<Ticket, TicketListItemDto, TicketSearchModel, ITicketRepository>(repository),
    IListTickets
{
	/// <summary>Maps a ticket entity to a list item without category or comment data.</summary>
	/// <param name="entity">The ticket entity to map.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task containing the mapped list item.</returns>
	protected override Task<TicketListItemDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
