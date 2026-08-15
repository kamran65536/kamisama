namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IRemoveAttachementFromTicketComment>]
internal class RemoveAttachementFromTicketComment(ITicketRepository repository) : IRemoveAttachementFromTicketComment
{
	/// <summary>
	/// Loads an attachment by identifier, removes it from its comment collection, and saves the owning ticket aggregate.
	/// The current implementation performs no caller, author, or ticket-editability check.
	/// </summary>
	/// <param name="attachmentId">The ticket attachment identifier to remove.</param>
	/// <param name="cancellationToken">The token forwarded to lookup and persistence.</param>
	/// <returns>A task that completes after the owning ticket is saved.</returns>
	public async Task DeleteAsync(Guid attachmentId, CancellationToken cancellationToken)
	{
        var attachment = await repository.FindTicketAttachmentByAttachmentIdAsync(attachmentId, cancellationToken) ?? throw new NotFoundException<TicketAttachment>(attachmentId, nameof(attachmentId));

        var comment = attachment.Comment;
        var ticket = attachment.Comment.Ticket;

        comment.Attachments.Remove(attachment);

        await repository.UpdateAsync(ticket, cancellationToken);
    }
}
