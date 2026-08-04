using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IAddCity>]
internal class AddCity(ICityRepository cityRepository, IProvinceRepository provinceRepository) :
	GenericAddFeature<AddCityRequest, ICityRepository, City, CityDto>(cityRepository),
	IAddCity
{
	protected override async Task<City> ConvertToEntity(AddCityRequest request, CancellationToken cancellationToken)
	{
		var province = await provinceRepository.FindByIdAsync(request.ProvinceId, cancellationToken)
			?? throw new NotFoundException<Province>(request.ProvinceId, nameof(request.ProvinceId));

		return new City
		{
			Name = request.Name,
			Province = province,
		};
	}

	protected override Task<CityDto> ConvertToDto(City entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
