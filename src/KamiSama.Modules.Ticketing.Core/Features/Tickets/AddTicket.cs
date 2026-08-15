namespace KamiSama.Modules.Ticketing.Features.Tickets;

[AutoInjectScoped<IAddTicket>]
internal class AddTicket(ITicketRepository repository, ITicketCategoryRepository ticketCategoryRepository) : 
    GenericAddFeature<AddTicketRequest, ITicketRepository, Ticket, TicketDto>(repository),
    IAddTicket
{
	/// <summary>
	/// Loads the requested category and creates an open ticket with an initial user comment and attachment references.
	/// Identifiers are left at their default values for EF Core value generation, and timestamps use the current UTC time.
	/// </summary>
	/// <param name="request">The complete ticket creation request.</param>
	/// <param name="cancellationToken">The token forwarded to category lookup.</param>
	/// <returns>The new ticket aggregate ready for repository persistence.</returns>
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
	/// <summary>Maps the persisted ticket aggregate to its complete public DTO.</summary>
	/// <param name="entity">The ticket entity to map.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task containing the mapped ticket.</returns>
	protected override Task<TicketDto> ConvertToDto(Ticket entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
