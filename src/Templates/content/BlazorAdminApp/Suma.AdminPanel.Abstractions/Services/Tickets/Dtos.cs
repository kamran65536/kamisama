namespace Suma.AdminPanel.Services.Tickets;

public record TicketSearchModel(
	int Page,
	int PageSize,
	string? Id,
	string? Title,
	TicketingStatus[]? Statuses,
	TicketPriority[]? Priorities,
	DateTime? From,
	DateTime? To,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	public static new TicketSearchModel All { get; } = new(default, default, default, default, default, default, default, default, default);
}

public record TicketListItemDto(
	string Subject,
	DateTime DateTime,
	Guid TicketId,
	TicketingStatus Status);

public record TicketAttachmentDto(
	Guid Id,
	Guid ContentId,
	Guid AuthorUserId);

public record TicketCommentDto(
	Guid Id,
	Guid AuthorUserId,
	string Description,
	TicketCommentSide Side,
	List<TicketAttachmentDto> Attachments,
	DateTime CreatedAt,
	DateTime UpdatedAt);

public record TicketDto(
	Guid Id,
	Guid AuthorUserId,
	string Subject,
	TicketingStatus Status,
	TicketPriority Priority,
	List<TicketCommentDto> Comments,
	DateTime CreatedAt,
	DateTime UpdatedAt);

public record AnswerTicketRequest(
	string Description,
	TicketingStatus? StatusAfterAnswer);

public record UpdateTicketStateRequest(
	string Subject,
	TicketingStatus Status,
	TicketPriority Priority);

public enum TicketCommentSide
{
	User = 1,
	Operator = 2,
}
