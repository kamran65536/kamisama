namespace KamiSama.Modules.Ticketing.Entities;

/// <summary>
/// Represents the persisted ticket aggregate root with category and comment navigations.
/// Core creates tickets in the open state and stores attachment references beneath comments.
/// </summary>
public class Ticket
{
    /// <summary>Gets or sets the ticket identifier.</summary>
    public Guid Id { get; set; }
    /// <summary>Gets or sets the required ticket title, limited to 100 characters by the EF Core model.</summary>
    [MaxLength(100)]
    public required string Title { get; set; }
    /// <summary>Gets or sets the identifier of the user who opened the ticket.</summary>
    public required Guid AuthorUserId { get; set; }
    /// <summary>Gets or sets the current workflow status.</summary>
    public required TicketStatus Status { get; set; }
    /// <summary>Gets or sets the current urgency.</summary>
    public required TicketPriority Priority { get; set; }
    /// <summary>Gets or sets the ticket creation timestamp.</summary>
    public required DateTime CreatedAt { get; set; }
    /// <summary>Gets or sets the latest ticket update timestamp.</summary>
    public required DateTime UpdatedAt { get; set; }
    /// <summary>Gets or sets the required category navigation.</summary>
    public required virtual TicketCategory Category { get; set; }
    /// <summary>Gets or sets the comments belonging to the ticket.</summary>
    public virtual ICollection<TicketComment> Comments { get; set; } = [];
    /// <summary>
    /// Determines whether the current status permits editing under the entity's workflow rule.
    /// Current feature services do not consistently invoke this rule before mutations.
    /// </summary>
    /// <returns><see langword="true"/> for open or reopened tickets; otherwise <see langword="false"/>.</returns>
    public bool IsEditable() => Status == TicketStatus.Reopened || Status == TicketStatus.Open;

    /// <summary>
    /// Determines whether the ticket can retain its current status or move to the requested status.
    /// Open and reopened tickets can be resolved, resolved tickets can be reopened or closed, and closed tickets are terminal.
    /// </summary>
    /// <param name="targetStatus">The status requested for the ticket.</param>
    /// <returns>True when the status is unchanged or the requested transition is allowed; otherwise false.</returns>
    public bool CanTransitionTo(TicketStatus targetStatus)
    {
        if (!Enum.IsDefined(Status) || !Enum.IsDefined(targetStatus))
            return false;

        return Status == targetStatus || (Status, targetStatus) switch
        {
            (TicketStatus.Open, TicketStatus.Resolved) => true,
            (TicketStatus.Reopened, TicketStatus.Resolved) => true,
            (TicketStatus.Resolved, TicketStatus.Reopened) => true,
            (TicketStatus.Resolved, TicketStatus.Closed) => true,
            _ => false
        };
    }
}
