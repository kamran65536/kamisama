using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IUpdateTicketCategory>]
internal class UpdateTicketCategory(ITicketCategoryRepository repository) :
	GenericUpdateFeature<UpdateTicketCategoryRequest, TicketCategory, ITicketCategoryRepository, Guid>(repository),
	IUpdateTicketCategory
{
	protected override async Task CheckDuplicateAsync(Guid id, UpdateTicketCategoryRequest request, CancellationToken cancellationToken)
	{
		var entity = await Repository.FindByNameAsync(request.Name, cancellationToken);

		if (entity != null && entity.Id != id)
			throw new AlreadyExistsException<TicketCategory>(request.Name, nameof(request.Name));
		
	}
	protected override Task PatchEntityAsync(TicketCategory entity, UpdateTicketCategoryRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		entity.UpdatedAt = DateTime.UtcNow;

		return Task.CompletedTask;
	}
}
