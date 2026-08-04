namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IFindTicketById>]
internal class FindTicketById(ITicketRepository repository) :
    GenericFindByIdFeature<Ticket, TicketDto, ITicketRepository, Guid>(repository),
    IFindTicketById
{
    protected override Task<TicketDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken)
        => Task.FromResult(entity.ToDto());
}
