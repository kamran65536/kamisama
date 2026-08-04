using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IDeleteProvince>]
internal class DeleteProvince(IProvinceRepository repository) :
	GenericDeleteFeature<Province, IProvinceRepository, Guid>(repository),
	IDeleteProvince
{
}
