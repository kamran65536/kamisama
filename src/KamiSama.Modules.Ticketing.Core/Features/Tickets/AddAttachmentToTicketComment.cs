namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IAddAttachmentToTicketComment>]
internal class AddAttachmentToTicketComment(ITicketRepository repository) : IAddAttachmentToTicketComment
{
	/// <summary>
	/// Loads a comment by request identifier, requires author-id equality, rejects content identifiers already attached to that comment, saves its ticket, and returns the aggregate.
	/// Caller authentication and content existence are outside this feature.
	/// </summary>
	/// <param name="request">The target comment, claimed author, and content identifiers.</param>
	/// <param name="cancellationToken">The token forwarded to lookup and persistence.</param>
	/// <returns>The updated complete ticket representation.</returns>
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
