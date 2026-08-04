using KamiSama.Modules.Ticketing.Features.Tickets;

namespace KamiSama.Modules.Ticketing.Repositories.Abstractions;

internal interface ITicketRepository : 
    IGenericRepository<Ticket, TicketSearchModel>,
    ILookupByIdRepository<Ticket, Guid>
{
    Task<TicketComment?> FindTicketCommentByCommentIdAsync(Guid commentId, CancellationToken cancellationToken);
    Task<TicketAttachment?> FindTicketAttachmentByAttachmentIdAsync(Guid attachmentId, CancellationToken cancellationToken);
}
