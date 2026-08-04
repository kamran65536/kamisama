using KamiSama.Modules.Ticketing.Features.TicketCategories;
using KamiSama.Modules.Ticketing.Features.Tickets;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IExistsTicketCategoryById>]
internal class ExistsTicketCategoryById(ITicketCategoryRepository repository) :
	GenericExistsByIdFeature<TicketCategory, ITicketCategoryRepository, Guid>(repository),
	IExistsTicketCategoryById
{
}
