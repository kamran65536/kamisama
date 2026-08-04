namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IUpdateTicketState>]
internal class UpdateTicketState(ITicketRepository repository) :
    GenericUpdateFeature<UpdateTicketStateRequest, Ticket, ITicketRepository, Guid>(repository),
    IUpdateTicketState
{
	protected override Task PatchEntityAsync(Ticket entity, UpdateTicketStateRequest request, CancellationToken cancellationToken)
	{
		entity.Status = request.Status;
		entity.Priority = request.Priority;
		entity.UpdatedAt = DateTime.UtcNow;
		entity.Title = request.Title;

		return Task.CompletedTask;
    }
}
