using KamiSama.Modules.Ticketing.Features.Tickets;

namespace KamiSama.Modules.Ticketing.Repositories.Abstractions;

internal interface ITicketRepository : 
    IGenericRepository<Ticket, TicketSearchModel>,
    ILookupByIdRepository<Ticket, Guid>
{
    /// <summary>Finds a ticket comment directly by its comment identifier.</summary>
    /// <param name="commentId">The comment identifier.</param>
    /// <param name="cancellationToken">The token forwarded to persistence.</param>
    /// <returns>The matching comment, or <see langword="null"/> when absent.</returns>
    Task<TicketComment?> FindTicketCommentByCommentIdAsync(Guid commentId, CancellationToken cancellationToken);
    /// <summary>Finds a ticket attachment directly by its attachment identifier.</summary>
    /// <param name="attachmentId">The attachment identifier.</param>
    /// <param name="cancellationToken">The token forwarded to persistence.</param>
    /// <returns>The matching attachment, or <see langword="null"/> when absent.</returns>
    Task<TicketAttachment?> FindTicketAttachmentByAttachmentIdAsync(Guid attachmentId, CancellationToken cancellationToken);
}
