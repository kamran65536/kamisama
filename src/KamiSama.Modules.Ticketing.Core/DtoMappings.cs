using KamiSama.Modules.Ticketing.Features.TicketCategories;
using KamiSama.Modules.Ticketing.Features.Tickets;
using Riok.Mapperly.Abstractions;

namespace KamiSama.Modules.Ticketing;

[Mapper]
internal static partial class DtoMappings
{
    /// <summary>Maps a ticket to the compact list representation without category or comments.</summary>
    /// <param name="entity">The ticket entity to map.</param>
    /// <returns>The mapped ticket list item.</returns>
    [MapperIgnoreSource(nameof(Ticket.Comments))]
    [MapperIgnoreSource(nameof(Ticket.Category))]
	public static partial TicketListItemDto ToListItemDto(this Ticket entity);
    /// <summary>Maps a ticket comment and its attachment collection to the public comment representation.</summary>
    /// <param name="entity">The comment entity to map.</param>
    /// <returns>The mapped ticket comment.</returns>
    [MapperIgnoreSource(nameof(TicketComment.Ticket))]
    public static partial TicketCommentDto ToDto(this TicketComment entity);
    /// <summary>Maps an attachment reference without its owning-comment navigation.</summary>
    /// <param name="entity">The attachment entity to map.</param>
    /// <returns>The mapped attachment reference.</returns>
    [MapperIgnoreSource(nameof(TicketAttachment.Comment))]
    public static partial TicketAttachmentDto ToDto(this TicketAttachment entity);
    /// <summary>Maps a ticket and its available category, comments, and attachments to the complete public representation.</summary>
    /// <param name="entity">The ticket aggregate to map.</param>
    /// <returns>The mapped complete ticket.</returns>
    public static partial TicketDto ToDto(this Ticket entity);
    /// <summary>Maps a category to its list-item representation.</summary>
    /// <param name="entity">The category entity to map.</param>
    /// <returns>The mapped category list item.</returns>
    public static partial TicketCategoryListItemDto ToListItemDto(this TicketCategory entity);
    /// <summary>Maps a category to its complete public representation.</summary>
    /// <param name="entity">The category entity to map.</param>
    /// <returns>The mapped category.</returns>
    public static partial TicketCategoryDto ToDto(this TicketCategory entity);
}
