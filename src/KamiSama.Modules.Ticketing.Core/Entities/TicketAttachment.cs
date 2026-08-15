namespace KamiSama.Modules.Ticketing.Entities;

/// <summary>
/// Represents a persisted reference from a ticket comment to content owned by another subsystem.
/// This entity stores identifiers only and does not contain attachment bytes or metadata.
/// </summary>
public class TicketAttachment
{
    /// <summary>Gets or sets the ticket attachment identifier.</summary>
    public Guid Id { get; set; }
    /// <summary>Gets or sets the required owning-comment navigation.</summary>
    public required virtual TicketComment Comment { get; set; }
    /// <summary>Gets or sets the external content identifier.</summary>
    public required Guid ContentId { get; set; }
    /// <summary>Gets or sets the identifier of the user who attached the content.</summary>
    public required Guid AuthorUserId { get; set; }
}
