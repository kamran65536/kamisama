using KamiSama.Extensions.Paging;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

public sealed record ItemNameListItemDto(KeyTypeToken Id);
public sealed record ItemNameDto(KeyTypeToken Id);
public sealed record AddItemNameRequest;
public sealed record UpdateItemNameRequest;
public sealed record ItemNameSearchModel(int Page = 1, int PageSize = 20, string? Search = null, string? OrderBy = null)
    : SearchModel(Page, PageSize, OrderBy);

// TODO(ai): Add panel-owned display, search, and editable fields. Do not leak bounded-context DTOs.
