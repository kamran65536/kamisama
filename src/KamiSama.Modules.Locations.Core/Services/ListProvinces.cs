using KamiSama.Modules.Locations.Features;
using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Services;

[AutoInjectScoped<IListProvinces>]
internal class ListProvinces(IProvinceRepository repository) :
	GenericListFeature<Province, ProvinceDto, ProvinceSearchModel, IProvinceRepository>(repository),
	IListProvinces
{
	protected override Task<ProvinceDto> ConvertToDto(Province entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
