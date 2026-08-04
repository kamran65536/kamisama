namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IAddTicket>]
internal class AddTicket(ITicketRepository repository, ITicketCategoryRepository ticketCategoryRepository) : 
    GenericAddFeature<AddTicketRequest, ITicketRepository, Ticket, TicketDto>(repository),
    IAddTicket
{
	protected override async Task<Ticket> ConvertToEntity(AddTicketRequest request, CancellationToken cancellationToken)
	{
		var category = await ticketCategoryRepository.FindByIdAsync(request.CategoryId, cancellationToken) ?? throw new NotFoundException<TicketCategory>(request.CategoryId, nameof(request.CategoryId));

		var ticket = new Ticket
		{
			Title = request.Title,
			Category =	category,
			Priority = request.Priority,
			Status = TicketStatus.Open,
			AuthorUserId = request.AuthorUserId,
            CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow,
		};

		var comment = new TicketComment
		{
			Ticket = ticket,
			Comment = request.InitialComment,
			AuthorUserId = request.AuthorUserId,
			Side = TicketCommentSide.User,
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow,
        };

		foreach (var attachmentContentId in request.InitialAttachmentContentIds)
		{
			var ticketAttachment = new TicketAttachment
			{
				Comment = comment,
				ContentId = attachmentContentId,
				AuthorUserId = request.AuthorUserId,
			};

			comment.Attachments.Add(ticketAttachment);
        }

		ticket.Comments.Add(comment);

		return ticket;
    }
	protected override Task<TicketDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
