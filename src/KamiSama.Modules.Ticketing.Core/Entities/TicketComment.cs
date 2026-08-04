namespace KamiSama.Modules.Ticketing.Entities;

public class TicketComment
{
	public Guid Id { get; set; }
	public required virtual Ticket Ticket { get; set; }
	[MaxLength(400)]
	public required string Comment { get; set; }
	public required TicketCommentSide Side { get; set; }
	public required virtual Guid AuthorUserId { get; set; }
	public required DateTime CreatedAt { get; set; }
	public required DateTime UpdatedAt { get; set; }
	public virtual ICollection<TicketAttachment> Attachments { get; set; } = [];
}
