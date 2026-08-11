using Microsoft.AspNetCore.Mvc;
using Suma.AdminPanel.Services.Tickets;

namespace Suma.AdminPanel.Server.Controllers;

/// <summary>
/// Provides ticket operations for AdminPanel.
/// </summary>
[Route("api/tickets")]
[ApiController]
public class TicketsController : ControllerBase
{
	/// <summary>
	/// Lists tickets using the given search model.
	/// </summary>
	[HttpGet]
	public Task<PagedResult<TicketListItemDto>> ListAsync(
		[FromServices] IListTickets service,
		[FromQuery] TicketSearchModel? searchModel,
		CancellationToken cancellationToken)
		=> service.ListAsync(searchModel ?? TicketSearchModel.All, cancellationToken);

	/// <summary>
	/// Finds a ticket by identifier.
	/// </summary>
	[HttpGet("{ticketId:guid}")]
	public Task<TicketDto> FindByIdAsync(
		[FromServices] IFindTicketById service,
		[FromRoute] Guid ticketId,
		CancellationToken cancellationToken)
		=> service.FindByIdAsync(ticketId, cancellationToken);

	/// <summary>
	/// Adds an operator answer to a ticket.
	/// </summary>
	[HttpPost("{ticketId:guid}/answer")]
	public Task<TicketDto> AnswerAsync(
		[FromServices] IAnswerTicket service,
		[FromRoute] Guid ticketId,
		[FromBody] AnswerTicketRequest request,
		CancellationToken cancellationToken)
		=> service.AnswerAsync(ticketId, request, cancellationToken);

	/// <summary>
	/// Updates ticket state fields.
	/// </summary>
	[HttpPut("{ticketId:guid}/state")]
	public Task UpdateStateAsync(
		[FromServices] IUpdateTicketState service,
		[FromRoute] Guid ticketId,
		[FromBody] UpdateTicketStateRequest request,
		CancellationToken cancellationToken)
		=> service.UpdateAsync(ticketId, request, cancellationToken);
}
