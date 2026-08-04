namespace KamiSama.Modules.Ticketing.Entities;

public class TicketAttachment
{
    public Guid Id { get; set; }
    public required virtual TicketComment Comment { get; set; }
    public required Guid ContentId { get; set; }
    public required Guid AuthorUserId { get; set; }
}
