namespace KamiSama.Modules.Ticketing.DataTypes;

/// <summary>
/// Identifies the workflow state of a ticket.
/// Core resolves open or reopened tickets, reopens or closes resolved tickets, and treats closed tickets as terminal.
/// </summary>
public enum TicketStatus : int
{
	/// <summary>The ticket is active, can be edited, and can transition to resolved.</summary>
    Open = 0,
	/// <summary>The ticket was reactivated after resolution, can be edited, and can transition to resolved.</summary>
    Reopened = 1,
	/// <summary>The reported issue has been resolved and can be reopened or closed.</summary>
    Resolved = 2,
	/// <summary>The ticket is closed, non-editable, and terminal.</summary>
    Closed = 3
}
