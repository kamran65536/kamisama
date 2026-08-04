using KamiSama.Modules.Ticketing.Features.TicketCategories;

namespace KamiSama.Modules.Ticketing.Repositories.Abstractions;

internal interface ITicketCategoryRepository :
	IGenericRepository<TicketCategory, TicketCategorySearchModel>,
	ILookupByIdRepository<TicketCategory, Guid>,
	ILookupByNameRepository<TicketCategory>
{
}
