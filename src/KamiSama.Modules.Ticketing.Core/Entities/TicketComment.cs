namespace KamiSama.Modules.Ticketing.Entities;

/// <summary>
/// Represents a persisted ticket comment with an author side and attachment references.
/// The required ticket navigation links the comment to its aggregate root.
/// </summary>
public class TicketComment
{
	/// <summary>Gets or sets the comment identifier.</summary>
	public Guid Id { get; set; }
	/// <summary>Gets or sets the required owning-ticket navigation.</summary>
	public required virtual Ticket Ticket { get; set; }
	/// <summary>Gets or sets the required comment text, limited to 400 characters by the EF Core model.</summary>
	[MaxLength(400)]
	public required string Comment { get; set; }
	/// <summary>Gets or sets whether the comment belongs to the user or operator side.</summary>
	public required TicketCommentSide Side { get; set; }
	/// <summary>Gets or sets the claimed author user identifier.</summary>
	public required virtual Guid AuthorUserId { get; set; }
	/// <summary>Gets or sets the comment creation timestamp.</summary>
	public required DateTime CreatedAt { get; set; }
	/// <summary>Gets or sets the latest comment update timestamp.</summary>
	public required DateTime UpdatedAt { get; set; }
	/// <summary>Gets or sets the external content references attached to the comment.</summary>
	public virtual ICollection<TicketAttachment> Attachments { get; set; } = [];
}
