using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IFindProvinceById>]
internal class FindProvinceById(IProvinceRepository repository) :
	GenericFindByIdFeature<Province, ProvinceDto, IProvinceRepository, Guid>(repository),
	IFindProvinceById
{
	protected override Task<ProvinceDto> ConvertToDto(Province entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
