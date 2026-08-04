using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IListCities>]
internal class ListCities(ICityRepository repository) :
	GenericListFeature<City, CityDto, CitySearchModel, ICityRepository>(repository),
	IListCities
{
	protected override Task<CityDto> ConvertToDto(City entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
