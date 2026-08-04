namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IUpdateTicketComment>]
internal class UpdateTicketComment(ITicketRepository repository) : IUpdateTicketComment
{
	public async Task UpdateAsync(Guid key, UpdateTicketCommentRequest request, CancellationToken cancellationToken)
	{
		var comment = await repository.FindTicketCommentByCommentIdAsync(request.CommentId, cancellationToken) ?? throw new NotFoundException<TicketComment>(request.CommentId, nameof(request.CommentId));

		var ticket = comment.Ticket;

		if (comment.AuthorUserId != request.AuthorUserId)
			throw new UnAuthorizedException();

		comment.Comment = request.Comment;
		comment.UpdatedAt = DateTime.UtcNow;

		await repository.UpdateAsync(ticket, cancellationToken);
    }
}
