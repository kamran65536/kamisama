# KamiSama.Modules.Locations.Abstractions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-neutral province and city feature contracts, requests, DTOs, and paging search models. Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.

## How to use

```shell
dotnet add package KamiSama.Modules.Locations.Abstractions --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.

Inject the feature contracts into application services or controllers after a concrete implementation, normally Locations Core, has registered them:

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Modules.Locations.Features;

public sealed class LocationsController(IListCities cities, IAddProvince addProvince)
{
    public Task<PagedResult<CityDto>> ListCitiesAsync(Guid provinceId, CancellationToken token)
        => cities.ListAsync(new CitySearchModel(1, 20, provinceId, null, null, "province"), token);

    public Task<ProvinceDto> AddProvinceAsync(string name, CancellationToken token)
        => addProvince.AddAsync(new AddProvinceRequest(name), token);
}
```

This package contains contracts and data shapes only: it registers no services, controllers, endpoints, persistence, validation pipeline, authentication, or authorization. Core's city queries can filter by city-name substring, exact province id, or province-name substring; `OrderBy = "province"` sorts by province then city, while every other value sorts by city. Province queries always sort by name regardless of `OrderBy`. The contracts do not promise those implementation details for alternative providers.

## Namespaces

- [KamiSama.Modules.Locations.Features](kamisama-modules-locations-features/index.md) (19 types)

## Types

- [KamiSama.Modules.Locations.Features.AddCityRequest](kamisama-modules-locations-features/kamisama-modules-locations-features-addcityrequest/index.md) - Carries an existing parent-province identifier and city name for creation. Core throws `NotFoundException<Province>` when the parent does not exist.
- [KamiSama.Modules.Locations.Features.AddProvinceRequest](kamisama-modules-locations-features/kamisama-modules-locations-features-addprovincerequest/index.md) - Carries the name for a new province. The name has a 100-character data-annotation limit, while uniqueness is not enforced by the Core add feature.
- [KamiSama.Modules.Locations.Features.CityDto](kamisama-modules-locations-features/kamisama-modules-locations-features-citydto/index.md) - Returns a city together with the identifier and name of its parent province. Parent values are copied from the loaded province navigation when Core creates the DTO.
- [KamiSama.Modules.Locations.Features.CitySearchModel](kamisama-modules-locations-features/kamisama-modules-locations-features-citysearchmodel/index.md) - Carries city paging, city and parent-province filters, and ordering. Core supports exact province-id filtering, lowercased city/province-name substrings, and the exact `province` ordering token.
- [KamiSama.Modules.Locations.Features.IAddCity](kamisama-modules-locations-features/kamisama-modules-locations-features-iaddcity/index.md) - Defines city creation beneath an existing province. Core loads the parent, saves the new city immediately, and does not check duplicate names.
- [KamiSama.Modules.Locations.Features.IAddProvince](kamisama-modules-locations-features/kamisama-modules-locations-features-iaddprovince/index.md) - Defines province creation from `AddProvinceRequest`. Core saves immediately and performs no duplicate-name check.
- [KamiSama.Modules.Locations.Features.IDeleteCity](kamisama-modules-locations-features/kamisama-modules-locations-features-ideletecity/index.md) - Defines city deletion by `Guid`. Core loads the row and saves its deletion immediately.
- [KamiSama.Modules.Locations.Features.IDeleteProvince](kamisama-modules-locations-features/kamisama-modules-locations-features-ideleteprovince/index.md) - Defines province deletion by `Guid`. Core saves immediately; the restricted relationship can make deletion fail while cities reference the province.
- [KamiSama.Modules.Locations.Features.IFindCityById](kamisama-modules-locations-features/kamisama-modules-locations-features-ifindcitybyid/index.md) - Defines city lookup by `Guid` and returns parent province data in the DTO. Core throws the generic city not-found HTTP exception when absent.
- [KamiSama.Modules.Locations.Features.IFindProvinceById](kamisama-modules-locations-features/kamisama-modules-locations-features-ifindprovincebyid/index.md) - Defines province lookup by `Guid`. Core throws the generic province not-found HTTP exception when no row matches.
- [KamiSama.Modules.Locations.Features.IListCities](kamisama-modules-locations-features/kamisama-modules-locations-features-ilistcities/index.md) - Defines paged city listing through `CitySearchModel`. Core can shape the query by city name, parent id, parent name, and the `province` order token.
- [KamiSama.Modules.Locations.Features.IListCitiesByProvinceName](kamisama-modules-locations-features/kamisama-modules-locations-features-ilistcitiesbyprovincename/index.md) - Defines city listing by a parent-province name substring. Core starts from `CitySearchModel.All`, so the result is page-shaped but contains all matches rather than a finite page.
- [KamiSama.Modules.Locations.Features.IListProvinces](kamisama-modules-locations-features/kamisama-modules-locations-features-ilistprovinces/index.md) - Defines paged province listing through `ProvinceSearchModel`. Core filters by a case-normalized name substring and always orders by name.
- [KamiSama.Modules.Locations.Features.IUpdateCity](kamisama-modules-locations-features/kamisama-modules-locations-features-iupdatecity/index.md) - Defines updating a city's name and parent province. Core requires the new parent to exist and saves the tracked entity immediately.
- [KamiSama.Modules.Locations.Features.IUpdateProvince](kamisama-modules-locations-features/kamisama-modules-locations-features-iupdateprovince/index.md) - Defines province update by `Guid`. Core replaces the name, saves immediately, and performs no duplicate-name check.
- [KamiSama.Modules.Locations.Features.ProvinceDto](kamisama-modules-locations-features/kamisama-modules-locations-features-provincedto/index.md) - Returns a province identifier and name across the provider-neutral feature boundary. It contains no child-city collection.
- [KamiSama.Modules.Locations.Features.ProvinceSearchModel](kamisama-modules-locations-features/kamisama-modules-locations-features-provincesearchmodel/index.md) - Carries province paging, optional name filtering, and an ordering token. Core performs a lowercased name substring filter and always orders by province name, ignoring the ordering token.
- [KamiSama.Modules.Locations.Features.UpdateCityRequest](kamisama-modules-locations-features/kamisama-modules-locations-features-updatecityrequest/index.md) - Carries the parent-province identifier and replacement city name. Core loads the requested parent before assigning both values and throws when that province does not exist.
- [KamiSama.Modules.Locations.Features.UpdateProvinceRequest](kamisama-modules-locations-features/kamisama-modules-locations-features-updateprovincerequest/index.md) - Carries the replacement name for an existing province. The name has a 100-character data-annotation limit, while uniqueness is not enforced by the Core update feature.
