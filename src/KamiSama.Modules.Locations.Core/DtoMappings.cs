using KamiSama.Modules.Locations.Features;

namespace KamiSama.Modules.Locations;

internal static class DtoMappings
{
	public static ProvinceDto ToDto(this Province entity)
		=> new(entity.Id, entity.Name);

	public static CityDto ToDto(this City entity)
		=> new(entity.Id, entity.Province.Id, entity.Province.Name, entity.Name);
}
