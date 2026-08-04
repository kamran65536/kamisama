using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IAddProvince>]
internal class AddProvince(IProvinceRepository repository) :
	GenericAddFeature<AddProvinceRequest, IProvinceRepository, Province, ProvinceDto>(repository),
	IAddProvince
{
	protected override Task<Province> ConvertToEntity(AddProvinceRequest request, CancellationToken cancellationToken)
		=> Task.FromResult(new Province
		{
			Name = request.Name,
		});

	protected override Task<ProvinceDto> ConvertToDto(Province entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
