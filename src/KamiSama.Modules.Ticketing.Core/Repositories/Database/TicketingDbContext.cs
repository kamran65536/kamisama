using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Ticketing.Repositories.Database;

/// <summary>
/// Provides the provider-neutral EF Core context consumed by Ticketing repositories and initializers.
/// A concrete provider context must be registered under the configured multi-provider key for normal module startup.
/// </summary>
public class TicketingDbContext : DbContext
{
    /// <summary>Gets or sets the tracked ticket entity set.</summary>
    public virtual DbSet<Ticket> Tickets { get; set; }
    /// <summary>Gets or sets the tracked ticket-category entity set.</summary>
    public virtual DbSet<TicketCategory> TicketCategories { get; set; }
    /// <summary>Gets or sets the tracked ticket-comment entity set.</summary>
    public virtual DbSet<TicketComment> TicketComments { get; set; }
    /// <summary>Gets or sets the tracked ticket-attachment entity set.</summary>
    public virtual DbSet<TicketAttachment> TicketAttachments { get; set; }

    /// <summary>
    /// Initializes the provider-neutral context with options typed for <see cref="TicketingDbContext"/>.
    /// Use this constructor when configuring the base context directly.
    /// </summary>
    /// <param name="options">The EF Core options for this context.</param>
    public TicketingDbContext(DbContextOptions<TicketingDbContext> options) : base(options)
    {
    }
    /// <summary>
    /// Initializes the base context with provider-specific options supplied by a derived context.
    /// Provider packages use this constructor from their concrete context types.
    /// </summary>
    /// <param name="options">The provider-specific EF Core options.</param>
    protected TicketingDbContext(DbContextOptions options) : base(options)
    {
    }
}
