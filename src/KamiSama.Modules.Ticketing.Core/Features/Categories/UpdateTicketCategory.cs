using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IUpdateTicketCategory>]
internal class UpdateTicketCategory(ITicketCategoryRepository repository) :
	GenericUpdateFeature<UpdateTicketCategoryRequest, TicketCategory, ITicketCategoryRepository, Guid>(repository),
	IUpdateTicketCategory
{
	/// <summary>Rejects a case-insensitive duplicate name owned by a category other than the update target.</summary>
	/// <param name="id">The category identifier being updated.</param>
	/// <param name="request">The request containing the replacement name.</param>
	/// <param name="cancellationToken">The token forwarded to the name lookup.</param>
	/// <returns>A task that completes when duplicate validation succeeds.</returns>
	protected override async Task CheckDuplicateAsync(Guid id, UpdateTicketCategoryRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);

		if (entity != null && entity.Id != id)
			throw new AlreadyExistsException<TicketCategory>(request.Name, nameof(request.Name));
		
	}
	/// <summary>Replaces the category name and records the current UTC update timestamp.</summary>
	/// <param name="entity">The tracked category entity to modify.</param>
	/// <param name="request">The request containing the replacement name.</param>
	/// <param name="cancellationToken">The unused operation token.</param>
	/// <returns>A completed task after the entity is patched.</returns>
	protected override Task PatchEntityAsync(TicketCategory entity, UpdateTicketCategoryRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		entity.UpdatedAt = DateTime.UtcNow;

		return Task.CompletedTask;
	}
}
