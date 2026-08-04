using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Tickets;

public record TicketSearchModel(int Page, int PageSize, string? Comment, Guid? TicketCategoryId, Guid? AuthorUserId, TicketStatus[]? Statuses, TicketPriority[]? Priorities, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
    public static new TicketSearchModel All { get; set; } = new (default, default, default, default, default, default, default, default);
}
public record TicketListItemDto(Guid Id, Guid AuthorUserId, string Title, TicketStatus Status, TicketPriority Priority, DateTime CreatedAt, DateTime UpdatedAt);
public record TicketAttachmentDto(Guid Id, Guid ContentId, Guid AuthorUserId);
public record TicketCommentDto(Guid Id, Guid AuthorUserId, string Comment, TicketCommentSide Side, List<TicketAttachmentDto> Attachments, DateTime CreatedAt, DateTime UpdatedAt);
public record TicketDto(Guid Id, Guid AuthorUserId, TicketCategoryListItemDto Category, string Title, TicketStatus Status, TicketPriority Priority, List<TicketCommentDto> Comments, DateTime CreatedAt, DateTime UpdatedAt);
public record AddTicketRequest(Guid AuthorUserId, string Title, Guid CategoryId, string InitialComment, TicketPriority Priority, List<Guid> InitialAttachmentContentIds);
public record UpdateTicketCommentRequest(Guid CommentId, Guid AuthorUserId, string Comment);
public record UpdateTicketStateRequest(string Title, TicketStatus Status, TicketPriority Priority);
public record AddTicketCommentRequest(Guid TicketId, Guid AuthorUserId, TicketCommentSide Side, string Comment, List<Guid> AttachmentContentIds);
public record AddAttachmentToTicketCommentRequest(Guid CommentId, Guid AuthorUserId, List<Guid> AttachmentContentIds);
