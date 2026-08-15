namespace KamiSama.Modules.Ticketing.DataTypes;
/// <summary>
/// Identifies whether a ticket comment is attributed to the user or operator side.
/// The value is supplied by comment callers except for the initial user comment created with a ticket.
/// </summary>
public enum TicketCommentSide
{
	/// <summary>The comment belongs to the user side.</summary>
	User = 1,
	/// <summary>The comment belongs to the operator side.</summary>
	Operator = 2
}
