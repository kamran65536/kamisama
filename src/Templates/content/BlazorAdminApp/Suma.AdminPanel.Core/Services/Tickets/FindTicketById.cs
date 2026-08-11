using TicketingFeatures = Polareum.Ticketing.Features.Tickets;

namespace Suma.AdminPanel.Services.Tickets;

[AutoInjectScoped<IFindTicketById>]
internal class FindTicketById(
	ILogger<FindTicketById> logger,
	TicketingFeatures.IFindTicketById findTicketById) : IFindTicketById
{
	public async Task<TicketDto> FindByIdAsync(Guid ticketId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();
		var ticket = await findTicketById.FindByIdAsync(ticketId, cancellationToken);
		return ticket.ToPanelDto();
	}
}

