using KamiSama.Modules.Ticketing.Features.TicketCategories;
using KamiSama.Modules.Ticketing.Features.Tickets;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IDeleteTicketCategory>]
internal class DeleteTicketCategory(ITicketCategoryRepository repository) :
	GenericDeleteFeature<TicketCategory, ITicketCategoryRepository, Guid>(repository)
{
}
