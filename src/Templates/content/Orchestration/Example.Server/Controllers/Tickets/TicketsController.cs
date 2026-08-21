using Example.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Server.Controllers.Tickets;

[ApiController, Authorize, Route("api/tickets")]
public sealed class TicketsController(IListAdminTickets tickets) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TicketSummary>>> List(CancellationToken cancellationToken)
        => Ok(await tickets.ListAsync(cancellationToken));
}
