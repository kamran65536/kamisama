namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IFindTicketById>]
internal class FindTicketById(ITicketRepository repository) :
    GenericFindByIdFeature<Ticket, TicketDto, ITicketRepository, Guid>(repository),
    IFindTicketById
{
    /// <summary>Maps the ticket found by identifier to its complete public DTO.</summary>
    /// <param name="entity">The ticket entity to map.</param>
    /// <param name="cancellationToken">The unused operation token.</param>
    /// <returns>A completed task containing the mapped ticket.</returns>
    protected override Task<TicketDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken)
        => Task.FromResult(entity.ToDto());
}
