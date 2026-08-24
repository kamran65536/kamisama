using System.Diagnostics.CodeAnalysis;
using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.DependencyInjection;
using SolutionToken.ContextToken.Repositories.Abstractions;
using SolutionToken.ContextToken.Repositories.Database;
using SolutionToken.ContextToken.Services.ServiceCategoryToken;

namespace SolutionToken.ContextToken.Repositories.Implementations;

[AutoInjectScoped<IItemNameRepository>]
[ExcludeFromCodeCoverage]
internal sealed class ItemNameRepository(ContextTokenDbContext context)
    : GenericRepository<ItemName, ItemNameSearchModel, ContextTokenDbContext>(context),
      IItemNameRepository
{
    public Task<ItemName?> FindByIdAsync(KeyTypeToken id, CancellationToken cancellationToken)
        => base.FindAsync(entity => entity.Id.Equals(id), cancellationToken);

    public Task<bool> ExistsByIdAsync(KeyTypeToken id, CancellationToken cancellationToken)
        => base.AnyAsync(entity => entity.Id.Equals(id), cancellationToken);

    protected override IQueryable<ItemName> ApplySearchModel(
        IQueryable<ItemName> query,
        ItemNameSearchModel searchModel)
    {
        // TODO(ai): Apply field filters and requested ordering.
        return query.OrderBy(entity => entity.Id);
    }
}
