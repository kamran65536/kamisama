using Example.ContextToken.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace Example.ContextToken.Repositories.ProviderToken;

public sealed class ProviderTokenContextTokenDbContext(
    DbContextOptions<ProviderTokenContextTokenDbContext> options) : ContextTokenDbContext(options);
