namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IUpdateTicketState>]
internal class UpdateTicketState(ITicketRepository repository) :
    GenericUpdateFeature<UpdateTicketStateRequest, Ticket, ITicketRepository, Guid>(repository),
    IUpdateTicketState
{
	/// <summary>
	/// Validates the requested status transition, replaces the ticket status, priority, and title, and records the current UTC update time.
	/// A same-status request remains valid so callers can change the title or priority without a workflow transition.
	/// </summary>
	/// <param name="entity">The tracked ticket entity to modify.</param>
	/// <param name="request">The replacement ticket state.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task after the entity is patched.</returns>
	/// <exception cref="ConflictException">The requested status transition is not allowed by the ticket workflow.</exception>
	protected override Task PatchEntityAsync(Ticket entity, UpdateTicketStateRequest request, CancellationToken cancellationToken)
	{
		if (!entity.CanTransitionTo(request.Status))
			throw new ConflictException("Ticket status cannot transition from {0} to {1}.", entity.Status, request.Status);

		entity.Status = request.Status;
		entity.Priority = request.Priority;
		entity.UpdatedAt = DateTime.UtcNow;
		entity.Title = request.Title;

		return Task.CompletedTask;
    }
}
