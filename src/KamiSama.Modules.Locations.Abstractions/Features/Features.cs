using KamiSama.Chassis.Commons.Features;
using KamiSama.Extensions.Paging;

namespace KamiSama.Modules.Locations.Features;

/// <summary>
/// Lists a page of provinces using province-specific filters and implementation-defined ordering.
/// </summary>
public interface IListProvinces : IListFeature<ProvinceDto, ProvinceSearchModel>;
/// <summary>
/// Finds a province by its <see cref="Guid"/> identifier and returns its provider-neutral DTO.
/// </summary>
public interface IFindProvinceById : IFindByIdFeature<ProvinceDto, Guid>;
/// <summary>
/// Adds a province from an <see cref="AddProvinceRequest"/> and returns the created province DTO.
/// </summary>
public interface IAddProvince : IAddFeature<AddProvinceRequest, ProvinceDto>;
/// <summary>
/// Updates the name of an existing province identified by <see cref="Guid"/>.
/// </summary>
public interface IUpdateProvince : IUpdateFeature<UpdateProvinceRequest, Guid>;
/// <summary>
/// Deletes an existing province identified by <see cref="Guid"/> according to implementation relationship rules.
/// </summary>
public interface IDeleteProvince : IDeleteFeature<Guid>;

/// <summary>
/// Lists a page of cities using city and parent-province filters and implementation-defined ordering.
/// </summary>
public interface IListCities : IListFeature<CityDto, CitySearchModel>;
/// <summary>
/// Finds a city by its <see cref="Guid"/> identifier and returns a DTO containing parent-province data.
/// </summary>
public interface IFindCityById : IFindByIdFeature<CityDto, Guid>;
/// <summary>
/// Adds a city beneath the province selected by <see cref="AddCityRequest.ProvinceId"/> and returns the created DTO.
/// </summary>
public interface IAddCity : IAddFeature<AddCityRequest, CityDto>;
/// <summary>
/// Updates an existing city's name and parent province from an <see cref="UpdateCityRequest"/>.
/// </summary>
public interface IUpdateCity : IUpdateFeature<UpdateCityRequest, Guid>;
/// <summary>
/// Deletes an existing city identified by <see cref="Guid"/> according to implementation persistence rules.
/// </summary>
public interface IDeleteCity : IDeleteFeature<Guid>;

/// <summary>
/// Lists all cities whose parent province name matches the supplied text according to the Core repository.
/// </summary>
public interface IListCitiesByProvinceName
{
	/// <summary>
	/// Returns an unpaged result filtered by a case-normalized substring of the related province name.
	/// </summary>
	/// <param name="provinceName">The province-name substring to match.</param>
	/// <param name="cancellationToken">A token that can cancel the database query.</param>
	/// <returns>A page-shaped result containing all matching city DTOs because the implementation starts from <see cref="CitySearchModel.All"/>.</returns>
	Task<PagedResult<CityDto>> ListAsync(string provinceName, CancellationToken cancellationToken);
}
