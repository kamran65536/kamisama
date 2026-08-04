using KamiSama.Extensions.Paging;
using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Locations.Features;

public record ProvinceSearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	public static new ProvinceSearchModel All { get; } = new(default, default, default, default);
}

public record CitySearchModel(int Page, int PageSize, Guid? ProvinceId, string? ProvinceName, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	public static new CitySearchModel All { get; } = new(default, default, default, default, default, default);
}

public record ProvinceDto(Guid Id, string Name);
public record CityDto(Guid Id, Guid ProvinceId, string ProvinceName, string Name);

public record AddProvinceRequest([property: MaxLength(100)] string Name);
public record UpdateProvinceRequest([property: MaxLength(100)] string Name);
public record AddCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
public record UpdateCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
