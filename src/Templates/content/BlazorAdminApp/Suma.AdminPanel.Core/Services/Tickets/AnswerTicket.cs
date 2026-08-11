using Polareum.Identity.Features.Users;
using TicketingDataTypes = Polareum.Ticketing.DataTypes;
using TicketingFeatures = Polareum.Ticketing.Features.Tickets;

namespace Suma.AdminPanel.Services.Tickets;

[AutoInjectScoped<IAnswerTicket>]
internal class AnswerTicket(
	ILogger<AnswerTicket> logger,
	IFindCurrentUser findCurrentUser,
	TicketingFeatures.IFindTicketById findTicketById,
	TicketingFeatures.IAddCommentToTicket addCommentToTicket,
	TicketingFeatures.IUpdateTicketState updateTicketState) : IAnswerTicket
{
	public async Task<TicketDto> AnswerAsync(Guid ticketId, AnswerTicketRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();
		var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);
		var ticket = await findTicketById.FindByIdAsync(ticketId, cancellationToken);
		await addCommentToTicket.AddAsync(
			new TicketingFeatures.AddTicketCommentRequest(
				ticketId,
				currentUser.Id,
				TicketingDataTypes.TicketCommentSide.Operator,
				request.Description,
				[]),
			cancellationToken);

		await updateTicketState.UpdateAsync(
			ticketId,
			new TicketingFeatures.UpdateTicketStateRequest(
				ticket.Title,
				TicketMappings.MapStatus(request.StatusAfterAnswer ?? TicketingStatus.Resolved),
				ticket.Priority),
			cancellationToken);

		var updatedTicket = await findTicketById.FindByIdAsync(ticketId, cancellationToken);
		return updatedTicket.ToPanelDto();
	}
}
