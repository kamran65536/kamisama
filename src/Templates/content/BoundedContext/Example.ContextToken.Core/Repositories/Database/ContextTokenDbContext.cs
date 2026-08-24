using Microsoft.EntityFrameworkCore;

namespace Example.ContextToken.Repositories.Database;

public class ContextTokenDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextTokenDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
