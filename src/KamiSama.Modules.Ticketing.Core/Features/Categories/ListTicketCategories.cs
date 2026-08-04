using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IListTicketCategories>]
internal class ListTicketCategories(ITicketCategoryRepository repository) :
	GenericListFeature<TicketCategory, TicketCategoryListItemDto, TicketCategorySearchModel, ITicketCategoryRepository>(repository)
{
	protected override Task<TicketCategoryListItemDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}