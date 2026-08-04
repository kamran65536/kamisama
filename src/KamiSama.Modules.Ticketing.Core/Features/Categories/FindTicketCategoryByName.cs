using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IFindTicketCategoryByName>]
internal class FindTicketCategoryByName(ITicketCategoryRepository repository) :
	GenericFindByNameFeature<TicketCategory, TicketCategoryDto, ITicketCategoryRepository>(repository),
	IFindTicketCategoryByName
{
	protected override Task<TicketCategoryDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
