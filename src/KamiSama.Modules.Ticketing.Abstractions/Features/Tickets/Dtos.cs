using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Tickets;

/// <summary>
/// Carries paging and optional ticket-list filters for text, category, author, status, priority, and ordering.
/// Core currently ignores <paramref name="TicketCategoryId"/> and recognizes <c>priority</c>, <c>status</c>, and <c>updatedat</c> ordering tokens.
/// </summary>
/// <param name="Page">The one-based page number, or the implementation-defined all-results value.</param>
/// <param name="PageSize">The maximum number of rows in a page, or the implementation-defined all-results value.</param>
/// <param name="Comment">Optional case-insensitive text matched against ticket titles and comment bodies by Core.</param>
/// <param name="TicketCategoryId">An optional category identifier; the current Core repository does not apply it.</param>
/// <param name="AuthorUserId">An optional user identifier matched against ticket or comment authors by Core.</param>
/// <param name="Statuses">Optional accepted ticket statuses.</param>
/// <param name="Priorities">Optional accepted ticket priorities.</param>
/// <param name="OrderBy">An optional implementation-specific ordering token.</param>
public record TicketSearchModel(int Page, int PageSize, string? Comment, Guid? TicketCategoryId, Guid? AuthorUserId, TicketStatus[]? Statuses, TicketPriority[]? Priorities, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
    /// <summary>
    /// Gets or sets the shared mutable search model requesting all tickets without filters or explicit ordering.
    /// Replace it only when application-wide callers intentionally need different all-results defaults.
    /// </summary>
    public static new TicketSearchModel All { get; set; } = new (default, default, default, default, default, default, default, default);
}
/// <summary>
/// Carries the ticket fields returned by list operations without category, comment, or attachment data.
/// Use a find operation when the complete aggregate is required.
/// </summary>
/// <param name="Id">The ticket identifier.</param>
/// <param name="AuthorUserId">The identifier of the user who opened the ticket.</param>
/// <param name="Title">The ticket title.</param>
/// <param name="Status">The current workflow status.</param>
/// <param name="Priority">The current urgency.</param>
/// <param name="CreatedAt">The ticket creation timestamp.</param>
/// <param name="UpdatedAt">The ticket's latest update timestamp.</param>
public record TicketListItemDto(Guid Id, Guid AuthorUserId, string Title, TicketStatus Status, TicketPriority Priority, DateTime CreatedAt, DateTime UpdatedAt);
/// <summary>
/// Carries a stored attachment reference without binary content.
/// Resolve <paramref name="ContentId"/> through the host application's content service.
/// </summary>
/// <param name="Id">The ticket attachment identifier.</param>
/// <param name="ContentId">The external content identifier.</param>
/// <param name="AuthorUserId">The identifier of the user who attached the content.</param>
public record TicketAttachmentDto(Guid Id, Guid ContentId, Guid AuthorUserId);
/// <summary>
/// Carries one ticket comment, its author and side, attachment references, and timestamps.
/// Attachment values contain external content identifiers rather than content bytes.
/// </summary>
/// <param name="Id">The comment identifier.</param>
/// <param name="AuthorUserId">The comment author's user identifier.</param>
/// <param name="Comment">The comment text.</param>
/// <param name="Side">Whether the comment belongs to the user or operator side.</param>
/// <param name="Attachments">The attachment references associated with the comment.</param>
/// <param name="CreatedAt">The comment creation timestamp.</param>
/// <param name="UpdatedAt">The comment's latest update timestamp.</param>
public record TicketCommentDto(Guid Id, Guid AuthorUserId, string Comment, TicketCommentSide Side, List<TicketAttachmentDto> Attachments, DateTime CreatedAt, DateTime UpdatedAt);
/// <summary>
/// Carries a complete ticket aggregate with category, comments, and attachment references.
/// Core mapping relies on the corresponding EF Core navigations being available.
/// </summary>
/// <param name="Id">The ticket identifier.</param>
/// <param name="AuthorUserId">The identifier of the user who opened the ticket.</param>
/// <param name="Category">The ticket category.</param>
/// <param name="Title">The ticket title.</param>
/// <param name="Status">The current workflow status.</param>
/// <param name="Priority">The current urgency.</param>
/// <param name="Comments">The ticket comments and their attachment references.</param>
/// <param name="CreatedAt">The ticket creation timestamp.</param>
/// <param name="UpdatedAt">The ticket's latest update timestamp.</param>
public record TicketDto(Guid Id, Guid AuthorUserId, TicketCategoryListItemDto Category, string Title, TicketStatus Status, TicketPriority Priority, List<TicketCommentDto> Comments, DateTime CreatedAt, DateTime UpdatedAt);
/// <summary>
/// Supplies the data used to open a ticket, create its initial user-side comment, and attach external content references.
/// Core requires the category to exist and forces the initial status to <see cref="TicketStatus.Open"/>.
/// </summary>
/// <param name="AuthorUserId">The identifier of the user opening the ticket and authoring its initial comment.</param>
/// <param name="Title">The ticket title.</param>
/// <param name="CategoryId">The identifier of an existing ticket category.</param>
/// <param name="InitialComment">The initial user-side comment text.</param>
/// <param name="Priority">The initial ticket priority.</param>
/// <param name="InitialAttachmentContentIds">External content identifiers to attach to the initial comment.</param>
public record AddTicketRequest(Guid AuthorUserId, string Title, Guid CategoryId, string InitialComment, TicketPriority Priority, List<Guid> InitialAttachmentContentIds);
/// <summary>
/// Supplies the comment identifier, claimed author, and replacement text for a comment update.
/// Current Core uses <paramref name="CommentId"/> instead of the separate update-method key and authorizes only by identifier equality.
/// </summary>
/// <param name="CommentId">The identifier of the comment to update.</param>
/// <param name="AuthorUserId">The claimed author identifier used by Core's ownership check.</param>
/// <param name="Comment">The replacement comment text.</param>
public record UpdateTicketCommentRequest(Guid CommentId, Guid AuthorUserId, string Comment);
/// <summary>
/// Supplies replacement title, status, and priority values for a ticket update.
/// Core permits unchanged status, open or reopened to resolved, and resolved to reopened or closed; it rejects every other transition.
/// </summary>
/// <param name="Title">The replacement ticket title.</param>
/// <param name="Status">The replacement workflow status, which must be reachable from the ticket's current status.</param>
/// <param name="Priority">The replacement urgency.</param>
public record UpdateTicketStateRequest(string Title, TicketStatus Status, TicketPriority Priority);
/// <summary>
/// Supplies a ticket identifier and the data for a new comment with optional attachment references.
/// Current Core accepts the requested side and author without checking ticket editability or caller identity.
/// </summary>
/// <param name="TicketId">The identifier of the ticket receiving the comment.</param>
/// <param name="AuthorUserId">The claimed comment author identifier.</param>
/// <param name="Side">The requested user or operator side.</param>
/// <param name="Comment">The comment text.</param>
/// <param name="AttachmentContentIds">External content identifiers to attach to the comment.</param>
public record AddTicketCommentRequest(Guid TicketId, Guid AuthorUserId, TicketCommentSide Side, string Comment, List<Guid> AttachmentContentIds);
/// <summary>
/// Supplies an existing comment, claimed author, and external content identifiers to attach.
/// Core requires author-id equality and rejects content identifiers already present on that comment.
/// </summary>
/// <param name="CommentId">The identifier of the comment receiving attachments.</param>
/// <param name="AuthorUserId">The claimed author identifier used by Core's ownership check.</param>
/// <param name="AttachmentContentIds">External content identifiers to add.</param>
public record AddAttachmentToTicketCommentRequest(Guid CommentId, Guid AuthorUserId, List<Guid> AttachmentContentIds);
