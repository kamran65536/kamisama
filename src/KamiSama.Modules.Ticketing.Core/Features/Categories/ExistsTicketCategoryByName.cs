using KamiSama.Modules.Ticketing.Features.TicketCategories;
using KamiSama.Modules.Ticketing.Features.Tickets;

namespace KamiSama.Modules.Ticketing.Features.Categories;

[AutoInjectScoped<IExistsTicketCategoryByName>]
internal class ExistsTicketCategoryByName(ITicketCategoryRepository repository) :
	GenericExistsByNameFeature<TicketCategory, ITicketCategoryRepository>(repository),
	IExistsByNameFeature
{
}
