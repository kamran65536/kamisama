using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IFindTicketCategoryById>]
internal class FindTicketCategoryById(ITicketCategoryRepository repository) :
	GenericFindByIdFeature<TicketCategory, TicketCategoryDto, ITicketCategoryRepository, Guid>(repository),
	IFindTicketCategoryById
{
	protected override Task<TicketCategoryDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
