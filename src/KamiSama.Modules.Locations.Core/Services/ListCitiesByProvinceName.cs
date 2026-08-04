using KamiSama.Extensions.Paging;
using KamiSama.Modules.Locations.Features;
using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Services;

[AutoInjectScoped<IListCitiesByProvinceName>]
internal class ListCitiesByProvinceName(ICityRepository cityRepository) : IListCitiesByProvinceName
{
	public async Task<PagedResult<CityDto>> ListAsync(string provinceName, CancellationToken cancellationToken)
	{
		var searchModel = CitySearchModel.All with { ProvinceName = provinceName };
		return (await cityRepository.ListAsync(searchModel, cancellationToken)).ConvertTo(x => x.ToDto());
	}
}
