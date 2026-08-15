using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IFindTicketCategoryByName>]
internal class FindTicketCategoryByName(ITicketCategoryRepository repository) :
	GenericFindByNameFeature<TicketCategory, TicketCategoryDto, ITicketCategoryRepository>(repository),
	IFindTicketCategoryByName
{
	/// <summary>Maps the category found by name to its public DTO.</summary>
	/// <param name="entity">The category entity to map.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task containing the mapped category.</returns>
	protected override Task<TicketCategoryDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
