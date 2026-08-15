using KamiSama.Extensions.Paging;
using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Locations.Features;

/// <summary>
/// Specifies paging, optional name filtering, and ordering input for province queries.
/// </summary>
/// <param name="Page">The one-based page number; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="PageSize">The requested page size; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="Name">An optional case-normalized substring matched against province names by the Core repository.</param>
/// <param name="OrderBy">An optional ordering token. The current Core repository ignores its value and always orders by province name.</param>
public record ProvinceSearchModel(int Page, int PageSize, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets an unpaged search model without name filtering or an ordering token.
	/// </summary>
	/// <value>A reusable model whose paging and optional filter values are all defaults.</value>
	public static new ProvinceSearchModel All { get; } = new(default, default, default, default);
}

/// <summary>
/// Specifies paging, province filters, city-name filtering, and ordering input for city queries.
/// </summary>
/// <param name="Page">The one-based page number; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="PageSize">The requested page size; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="ProvinceId">An optional province identifier matched exactly through the city relationship.</param>
/// <param name="ProvinceName">An optional case-normalized substring matched against the related province name.</param>
/// <param name="Name">An optional case-normalized substring matched against city names.</param>
/// <param name="OrderBy">Use <c>province</c> for province-name then city-name ordering; every other value orders by city name.</param>
public record CitySearchModel(int Page, int PageSize, Guid? ProvinceId, string? ProvinceName, string? Name, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets an unpaged search model without province or city filters.
	/// </summary>
	/// <value>A reusable model whose paging, filters, and ordering token are all defaults.</value>
	public static new CitySearchModel All { get; } = new(default, default, default, default, default, default);
}

/// <summary>
/// Represents a province returned across the provider-neutral Locations feature boundary.
/// </summary>
/// <param name="Id">The province identifier.</param>
/// <param name="Name">The province name.</param>
public record ProvinceDto(Guid Id, string Name);
/// <summary>
/// Represents a city and its parent province across the provider-neutral Locations feature boundary.
/// </summary>
/// <param name="Id">The city identifier.</param>
/// <param name="ProvinceId">The parent province identifier.</param>
/// <param name="ProvinceName">The parent province name captured when the DTO is created.</param>
/// <param name="Name">The city name.</param>
public record CityDto(Guid Id, Guid ProvinceId, string ProvinceName, string Name);

/// <summary>
/// Supplies the name for a new province.
/// </summary>
/// <param name="Name">The province name, limited to 100 characters by data annotations and the Core EF model.</param>
public record AddProvinceRequest([property: MaxLength(100)] string Name);
/// <summary>
/// Supplies the replacement name for an existing province.
/// </summary>
/// <param name="Name">The province name, limited to 100 characters by data annotations and the Core EF model.</param>
public record UpdateProvinceRequest([property: MaxLength(100)] string Name);
/// <summary>
/// Supplies the parent province and name for a new city.
/// </summary>
/// <param name="ProvinceId">The identifier of an existing parent province.</param>
/// <param name="Name">The city name, limited to 100 characters by data annotations and the Core EF model.</param>
public record AddCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
/// <summary>
/// Supplies the parent province and replacement name for an existing city.
/// </summary>
/// <param name="ProvinceId">The identifier of an existing province to assign as the parent.</param>
/// <param name="Name">The city name, limited to 100 characters by data annotations and the Core EF model.</param>
public record UpdateCityRequest(Guid ProvinceId, [property: MaxLength(100)] string Name);
