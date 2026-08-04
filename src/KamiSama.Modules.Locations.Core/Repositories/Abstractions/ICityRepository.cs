using KamiSama.Modules.Locations.Features;

namespace KamiSama.Modules.Locations.Repositories.Abstractions;

internal interface ICityRepository :
	IGenericRepository<City, CitySearchModel>,
	ILookupByIdRepository<City, Guid>
{
}
