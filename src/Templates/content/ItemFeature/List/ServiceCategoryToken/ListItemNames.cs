using KamiSama.Chassis.Commons.Features;
using KamiSama.Extensions.Paging;

namespace NamespaceToken.Services.ServiceCategoryToken;

public sealed record ItemNameDto(KeyTypeToken Id);
public sealed record ItemNameSearchModel(int Page = 1, int PageSize = 20, string? OrderBy = null)
    : SearchModel(Page, PageSize, OrderBy);
public interface IListItemNames : IListFeature<ItemNameDto, ItemNameSearchModel>;

internal sealed class ListItemNames : IListItemNames
{
    public Task<PagedResult<ItemNameDto>> ListAsync(ItemNameSearchModel searchModel, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Apply filters and return a paged result.");
}
