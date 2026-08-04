using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IUpdateProvince>]
internal class UpdateProvince(IProvinceRepository repository) :
	GenericUpdateFeature<UpdateProvinceRequest, Province, IProvinceRepository, Guid>(repository),
	IUpdateProvince
{
	protected override Task PatchEntityAsync(Province entity, UpdateProvinceRequest request, CancellationToken cancellationToken)
	{
		entity.Name = request.Name;
		return Task.CompletedTask;
	}
}
