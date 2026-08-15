using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IListTicketCategories>]
internal class ListTicketCategories(ITicketCategoryRepository repository) :
	GenericListFeature<TicketCategory, TicketCategoryListItemDto, TicketCategorySearchModel, ITicketCategoryRepository>(repository)
{
	/// <summary>Maps a category entity to the compact category list representation.</summary>
	/// <param name="entity">The category entity to map.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task containing the mapped list item.</returns>
	protected override Task<TicketCategoryListItemDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
