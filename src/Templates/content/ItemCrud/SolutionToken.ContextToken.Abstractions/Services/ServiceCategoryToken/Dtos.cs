using KamiSama.Extensions.Paging;

namespace SolutionToken.ContextToken.Services.ServiceCategoryToken;

public sealed record ItemNameDto(KeyTypeToken Id);
public sealed record AddItemNameRequest;
public sealed record UpdateItemNameRequest;

public sealed record ItemNameSearchModel(
    int Page = 1,
    int PageSize = 20,
    string? OrderBy = null)
    : SearchModel(Page, PageSize, OrderBy);

// TODO(ai): Add searchable/editable fields to these DTOs; dotnet templates cannot loop over arbitrary fields.
