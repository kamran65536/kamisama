namespace KamiSama.Modules.Ticketing.Entities;

public class TicketCategory
{
	public Guid Id { get; set; }
	[MaxLength(50)]
	public required string Name { get; set; }
	public required DateTime CreatedAt { get; set; }
	public required DateTime UpdatedAt { get; set; }
}
