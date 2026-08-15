namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IUpdateTicketComment>]
internal class UpdateTicketComment(ITicketRepository repository) : IUpdateTicketComment
{
	/// <summary>
	/// Loads the comment identified by <paramref name="request"/>, requires author-id equality, replaces its text and UTC update time, and saves the owning ticket.
	/// The separate <paramref name="key"/> is ignored, and caller authentication and ticket editability are not checked.
	/// </summary>
	/// <param name="key">The common update-contract key; the current implementation does not use it.</param>
	/// <param name="request">The actual comment identifier, claimed author, and replacement text.</param>
	/// <param name="cancellationToken">The token forwarded to lookup and persistence.</param>
	/// <returns>A task that completes after the owning ticket is saved.</returns>
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
