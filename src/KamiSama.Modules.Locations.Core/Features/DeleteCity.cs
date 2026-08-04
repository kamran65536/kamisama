using KamiSama.Modules.Locations.Repositories.Abstractions;

namespace KamiSama.Modules.Locations.Features;

[AutoInjectScoped<IDeleteCity>]
internal class DeleteCity(ICityRepository repository) :
	GenericDeleteFeature<City, ICityRepository, Guid>(repository),
	IDeleteCity
{
}
