using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IFindCityById>]
internal class FindCityById(ICityRepository repository) :
	GenericFindByIdFeature<City, CityDto, ICityRepository, Guid>(repository),
	IFindCityById
{
	protected override Task<CityDto> ConvertToDto(City entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
