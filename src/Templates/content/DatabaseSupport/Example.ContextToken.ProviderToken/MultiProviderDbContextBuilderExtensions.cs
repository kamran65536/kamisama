using Example.ContextToken.Repositories.Database;
using Example.ContextToken.Repositories.ProviderToken;
using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Repositories.EntityFrameworkCore.ProviderToken;

namespace Example.ContextToken;

public static class MultiProviderDbContextBuilderExtensions
{
    public static IMultiProviderDbContextBuilder<ContextTokenDbContext> AddProviderToken(
        this IMultiProviderDbContextBuilder<ContextTokenDbContext> builder)
        => builder.AddProviderToken<ContextTokenDbContext, ProviderTokenContextTokenDbContext>();
}
