using KamiSama.Chassis.Commons.Features;
using KamiSama.Extensions.Paging;

namespace KamiSama.Modules.Locations.Features;

public interface IListProvinces : IListFeature<ProvinceDto, ProvinceSearchModel>;
public interface IFindProvinceById : IFindByIdFeature<ProvinceDto, Guid>;
public interface IAddProvince : IAddFeature<AddProvinceRequest, ProvinceDto>;
public interface IUpdateProvince : IUpdateFeature<UpdateProvinceRequest, Guid>;
public interface IDeleteProvince : IDeleteFeature<Guid>;

public interface IListCities : IListFeature<CityDto, CitySearchModel>;
public interface IFindCityById : IFindByIdFeature<CityDto, Guid>;
public interface IAddCity : IAddFeature<AddCityRequest, CityDto>;
public interface IUpdateCity : IUpdateFeature<UpdateCityRequest, Guid>;
public interface IDeleteCity : IDeleteFeature<Guid>;

public interface IListCitiesByProvinceName
{
	Task<PagedResult<CityDto>> ListAsync(string provinceName, CancellationToken cancellationToken);
}
