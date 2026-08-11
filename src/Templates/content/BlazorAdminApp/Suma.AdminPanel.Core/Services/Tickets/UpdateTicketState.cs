using TicketingFeatures = Polareum.Ticketing.Features.Tickets;

namespace Suma.AdminPanel.Services.Tickets;

[AutoInjectScoped<IUpdateTicketState>]
internal class UpdateTicketState(
	ILogger<UpdateTicketState> logger,
	TicketingFeatures.IUpdateTicketState updateTicketState) : IUpdateTicketState
{
	public async Task UpdateAsync(Guid ticketId, UpdateTicketStateRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();
		await updateTicketState.UpdateAsync(
			ticketId,
			new TicketingFeatures.UpdateTicketStateRequest(
				request.Subject,
				TicketMappings.MapStatus(request.Status),
				TicketMappings.MapPriority(request.Priority)),
			cancellationToken);
	}
}

