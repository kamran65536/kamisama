namespace KamiSama.Modules.Ticketing.Entities;

public class Ticket
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public required string Title { get; set; }
    public required Guid AuthorUserId { get; set; }
    public required TicketStatus Status { get; set; }
    public required TicketPriority Priority { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public required virtual TicketCategory Category { get; set; }
    public virtual ICollection<TicketComment> Comments { get; set; } = [];
    public bool IsEditable() => Status == TicketStatus.Reopened || Status == TicketStatus.Open;
}