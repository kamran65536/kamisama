using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Ticketing.Repositories.Database;

public class TicketingDbContext : DbContext
{
    public virtual DbSet<Ticket> Tickets { get; set; }
    public virtual DbSet<TicketCategory> TicketCategories { get; set; }
    public virtual DbSet<TicketComment> TicketComments { get; set; }
    public virtual DbSet<TicketAttachment> TicketAttachments { get; set; }

    public TicketingDbContext(DbContextOptions<TicketingDbContext> options) : base(options)
    {
    }
    protected TicketingDbContext(DbContextOptions options) : base(options)
    {
    }
}
