using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IAddTicketCategory>]
internal class AddTicketCategory(ITicketCategoryRepository repository) :
	GenericAddFeature<AddTicketCategoryRequest, ITicketCategoryRepository, TicketCategory, TicketCategoryDto>(repository),
	IAddTicketCategory
{
	/// <summary>Rejects a case-insensitive category-name duplicate before creation.</summary>
	/// <param name="request">The category creation request.</param>
	/// <param name="cancellationToken">The token forwarded to the existence query.</param>
	/// <returns>A task that completes when duplicate validation succeeds.</returns>
	protected override async Task CheckDuplicateAsync(AddTicketCategoryRequest request, CancellationToken cancellationToken)
	{
		if (await Repository.ExistsByNameAsync(request.Name, cancellationToken))
			throw new AlreadyExistsException<TicketCategory>(request.Name, nameof(request.Name));
	}

	/// <summary>Creates a category entity with current UTC creation and update timestamps.</summary>
	/// <param name="request">The request containing the category name.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task containing the new category entity.</returns>
	protected override Task<TicketCategory> ConvertToEntity(AddTicketCategoryRequest request, CancellationToken cancellationToken)
		=> Task.FromResult(new TicketCategory
		{
			Name = request.Name,
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow,
		});
	/// <summary>Maps the persisted category entity to its public DTO.</summary>
	/// <param name="entity">The category entity to map.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task containing the mapped category.</returns>
	protected override Task<TicketCategoryDto> ConvertToDto(TicketCategory entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
