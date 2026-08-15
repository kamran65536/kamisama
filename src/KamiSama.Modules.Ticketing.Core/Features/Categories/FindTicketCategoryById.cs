using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IFindTicketCategoryById>]
internal class FindTicketCategoryById(ITicketCategoryRepository repository) :
	GenericFindByIdFeature<TicketCategory, TicketCategoryDto, ITicketCategoryRepository, Guid>(repository),
	IFindTicketCategoryById
{
	/// <summary>Maps the category found by identifier to its public DTO.</summary>
	/// <param name="entity">The category entity to map.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task containing the mapped category.</returns>
	protected override Task<TicketCategoryDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
