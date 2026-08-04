namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IAddCommentToTicket>]
internal class AddCommentToTicket(ITicketRepository repository) : IAddCommentToTicket
{
	public async Task<TicketDto> AddAsync(AddTicketCommentRequest request, CancellationToken cancellationToken)
	{
		var ticket = await repository.FindByIdAsync(request.TicketId, cancellationToken) ?? throw new NotFoundException<Ticket>(request.TicketId, nameof(request.TicketId));

		var comment = new TicketComment
		{
			Ticket = ticket,
			AuthorUserId = request.AuthorUserId,
			Comment = request.Comment,
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow,
			Side = request.Side,
        };

		foreach (var attachmentId in request.AttachmentContentIds)
		{
			comment.Attachments.Add(new TicketAttachment
			{
				Comment = comment,
				ContentId = attachmentId,
				AuthorUserId = request.AuthorUserId,
			});
        }

		ticket.Comments.Add(comment);

		await repository.UpdateAsync(ticket, cancellationToken);

		return ticket.ToDto();
    }
}
