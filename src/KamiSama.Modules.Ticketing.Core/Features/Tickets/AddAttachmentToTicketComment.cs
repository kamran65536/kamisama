namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IAddAttachmentToTicketComment>]
internal class AddAttachmentToTicketComment(ITicketRepository repository) : IAddAttachmentToTicketComment
{
	public async Task<TicketDto> AddAsync(AddAttachmentToTicketCommentRequest request, CancellationToken cancellationToken)
	{
        var comment = await repository.FindTicketCommentByCommentIdAsync(request.CommentId, cancellationToken) ?? throw new NotFoundException<TicketComment>(request.CommentId, nameof(request.CommentId));

        var ticket = comment.Ticket;

        if (comment.AuthorUserId != request.AuthorUserId)
            throw new UnAuthorizedException();

        foreach (var attachmentContentId in request.AttachmentContentIds)
        {
            if (comment.Attachments.Any(a => a.ContentId == attachmentContentId))
                throw new AlreadyExistsException<TicketAttachment>(attachmentContentId, nameof(attachmentContentId));

            comment.Attachments.Add(new TicketAttachment
            {
                Comment = comment,
                AuthorUserId = comment.AuthorUserId,
                ContentId = attachmentContentId,
            });
        }

        await repository.UpdateAsync(ticket, cancellationToken);

        return ticket.ToDto();
    }
}
