namespace KamiSama.Modules.Ticketing.Features.TicketCategories;

public record TicketCategorySearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
    public static new TicketCategorySearchModel All { get; set; } = new(default, default, default, default);
}
public record TicketCategoryListItemDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
public record TicketCategoryDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
public record AddTicketCategoryRequest(string Name);
public record UpdateTicketCategoryRequest(string Name);
