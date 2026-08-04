namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IRemoveAttachementFromTicketComment>]
internal class RemoveAttachementFromTicketComment(ITicketRepository repository) : IRemoveAttachementFromTicketComment
{
	public async Task DeleteAsync(Guid attachmentId, CancellationToken cancellationToken)
	{
        var attachment = await repository.FindTicketAttachmentByAttachmentIdAsync(attachmentId, cancellationToken) ?? throw new NotFoundException<TicketAttachment>(attachmentId, nameof(attachmentId));

        var comment = attachment.Comment;
        var ticket = attachment.Comment.Ticket;

        comment.Attachments.Remove(attachment);

        await repository.UpdateAsync(ticket, cancellationToken);
    }
}
