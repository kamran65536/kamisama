namespace KamiSama.Modules.Ticketing.Features.TicketCategories;

/// <summary>
/// Carries paging, optional name filtering, and ordering for ticket-category lists.
/// Core performs a case-insensitive exact name comparison and recognizes <c>id</c>, <c>name</c>, <c>createdat</c>, and <c>updatedat</c> ordering tokens.
/// </summary>
/// <param name="Page">The one-based page number, or the implementation-defined all-results value.</param>
/// <param name="PageSize">The maximum number of rows in a page, or the implementation-defined all-results value.</param>
/// <param name="Name">An optional category name filter.</param>
/// <param name="OrderBy">An optional implementation-specific ordering token.</param>
public record TicketCategorySearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
    /// <summary>
    /// Gets or sets the shared mutable search model requesting all categories without a name or ordering filter.
    /// Replace it only when application-wide callers intentionally need different all-results defaults.
    /// </summary>
    public static new TicketCategorySearchModel All { get; set; } = new(default, default, default, default);
}
/// <summary>
/// Carries the category fields returned in ticket-category list results and nested ticket data.
/// It contains no ticket collection.
/// </summary>
/// <param name="Id">The category identifier.</param>
/// <param name="Name">The category name.</param>
/// <param name="CreatedAt">The category creation timestamp.</param>
/// <param name="UpdatedAt">The category's latest update timestamp.</param>
public record TicketCategoryListItemDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
/// <summary>
/// Carries the complete public representation of a ticket category.
/// The current shape is the same as the list-item representation.
/// </summary>
/// <param name="Id">The category identifier.</param>
/// <param name="Name">The category name.</param>
/// <param name="CreatedAt">The category creation timestamp.</param>
/// <param name="UpdatedAt">The category's latest update timestamp.</param>
public record TicketCategoryDto(Guid Id, string Name, DateTime CreatedAt, DateTime UpdatedAt);
/// <summary>
/// Supplies the name for a new ticket category.
/// Core checks the name for a case-insensitive duplicate before saving.
/// </summary>
/// <param name="Name">The category name to create.</param>
public record AddTicketCategoryRequest(string Name);
/// <summary>
/// Supplies the replacement name for an existing ticket category.
/// The target category identifier is passed separately to the update feature.
/// </summary>
/// <param name="Name">The replacement category name.</param>
public record UpdateTicketCategoryRequest(string Name);
