using KamiSama.Modules.Locations.Features;

namespace KamiSama.Modules.Locations.Repositories.Abstractions;

internal interface IProvinceRepository :
	IGenericRepository<Province, ProvinceSearchModel>,
	ILookupByIdRepository<Province, Guid>
{
}
