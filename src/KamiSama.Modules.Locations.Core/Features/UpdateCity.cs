using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IUpdateCity>]
internal class UpdateCity(ICityRepository cityRepository, IProvinceRepository provinceRepository) :
	GenericUpdateFeature<UpdateCityRequest, City, ICityRepository, Guid>(cityRepository),
	IUpdateCity
{
	protected override async Task PatchEntityAsync(City entity, UpdateCityRequest request, CancellationToken cancellationToken)
	{
		var province = await provinceRepository.FindByIdAsync(request.ProvinceId, cancellationToken)
			?? throw new NotFoundException<Province>(request.ProvinceId, nameof(request.ProvinceId));

		entity.Name = request.Name;
		entity.Province = province;
	}
}
