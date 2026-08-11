namespace Suma.AdminPanel.Services.Tickets;

public interface IListTickets : IListFeature<TicketListItemDto, TicketSearchModel>;

public interface IFindTicketById
{
	Task<TicketDto> FindByIdAsync(Guid ticketId, CancellationToken cancellationToken);
}

public interface IAnswerTicket
{
	Task<TicketDto> AnswerAsync(Guid ticketId, AnswerTicketRequest request, CancellationToken cancellationToken);
}

public interface IUpdateTicketState
{
	Task UpdateAsync(Guid ticketId, UpdateTicketStateRequest request, CancellationToken cancellationToken);
}

