using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IAddTicketCategory>]
internal class AddTicketCategory(ITicketCategoryRepository repository) :
	GenericAddFeature<AddTicketCategoryRequest, ITicketCategoryRepository, TicketCategory, TicketCategoryDto>(repository),
	IAddTicketCategory
{
	protected override async Task CheckDuplicateAsync(AddTicketCategoryRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
			throw new AlreadyExistsException<TicketCategory>(request.Name, nameof(request.Name));
	}

	protected override Task<TicketCategory> ConvertToEntity(AddTicketCategoryRequest request, CancellationToken cancellationToken)
		=> Task.FromResult(new TicketCategory
		{
			Name = request.Name,
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow,
		});
	protected override Task<TicketCategoryDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
