namespace KamiSama.Modules.Ticketing.DataTypes;

/// <summary>
/// Identifies the urgency assigned to a ticket.
/// Core stores the numeric value and uses it as the default primary list ordering.
/// </summary>
public enum TicketPriority : int
{
	/// <summary>The lowest available urgency.</summary>
	Low = 0,
	/// <summary>A normal intermediate urgency.</summary>
	Medium = 1,
	/// <summary>An elevated urgency.</summary>
	High = 2,
	/// <summary>The highest available urgency.</summary>
	Critical = 3
}
