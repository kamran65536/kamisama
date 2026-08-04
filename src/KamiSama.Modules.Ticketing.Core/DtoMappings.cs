using KamiSama.Modules.Ticketing.Features.TicketCategories;
using KamiSama.Modules.Ticketing.Features.Tickets;
using Riok.Mapperly.Abstractions;

namespace KamiSama.Modules.Ticketing;

[Mapper]
internal static partial class DtoMappings
{
    [MapperIgnoreSource(nameof(Ticket.Comments))]
    [MapperIgnoreSource(nameof(Ticket.Category))]
	public static partial TicketListItemDto ToListItemDto(this Ticket entity);
    [MapperIgnoreSource(nameof(TicketComment.Ticket))]
    public static partial TicketCommentDto ToDto(this TicketComment entity);
    [MapperIgnoreSource(nameof(TicketAttachment.Comment))]
    public static partial TicketAttachmentDto ToDto(this TicketAttachment entity);
    public static partial TicketDto ToDto(this Ticket entity);
    public static partial TicketCategoryListItemDto ToListItemDto(this TicketCategory entity);
    public static partial TicketCategoryDto ToDto(this TicketCategory entity);
}
