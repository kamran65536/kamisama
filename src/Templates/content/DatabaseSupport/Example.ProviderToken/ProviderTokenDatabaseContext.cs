using Microsoft.EntityFrameworkCore;

namespace Example.ProviderToken;

public sealed class ProviderTokenDatabaseContext(DbContextOptions<ProviderTokenDatabaseContext> options)
    : DbContext(options);
