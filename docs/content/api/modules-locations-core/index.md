# KamiSama.Modules.Locations.Core

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Locations module implementation with province and city entities, repositories, features, and web-module setup. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Modules.Locations.Core --version 10.0.10
```

## Namespaces

- [KamiSama.Modules.Locations](kamisama-modules-locations/index.md) (3 types)
- [KamiSama.Modules.Locations.Entities](kamisama-modules-locations-entities/index.md) (2 types)
- [KamiSama.Modules.Locations.Features](kamisama-modules-locations-features/index.md) (9 types)
- [KamiSama.Modules.Locations.Repositories.Abstractions](kamisama-modules-locations-repositories-abstractions/index.md) (2 types)
- [KamiSama.Modules.Locations.Repositories.Database](kamisama-modules-locations-repositories-database/index.md) (1 types)
- [KamiSama.Modules.Locations.Repositories.Implementations](kamisama-modules-locations-repositories-implementations/index.md) (2 types)
- [KamiSama.Modules.Locations.Services](kamisama-modules-locations-services/index.md) (2 types)

## Types

- [KamiSama.Modules.Locations.DtoMappings](kamisama-modules-locations/kamisama-modules-locations-dtomappings/index.md) - Provides the `DtoMappings` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.ExtendedWebApplicationBuilderExtensions](kamisama-modules-locations/kamisama-modules-locations-extendedwebapplicationbuilderextensions/index.md) - Provides the `ExtendedWebApplicationBuilderExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.LocationsModule](kamisama-modules-locations/kamisama-modules-locations-locationsmodule/index.md) - ASP.NET Core web-module implementation for `LocationsModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.
- [KamiSama.Modules.Locations.Entities.City](kamisama-modules-locations-entities/kamisama-modules-locations-entities-city/index.md) - Provides the `City` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Entities.Province](kamisama-modules-locations-entities/kamisama-modules-locations-entities-province/index.md) - Provides the `Province` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.AddCity](kamisama-modules-locations-features/kamisama-modules-locations-features-addcity/index.md) - Provides the `AddCity` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.AddProvince](kamisama-modules-locations-features/kamisama-modules-locations-features-addprovince/index.md) - Provides the `AddProvince` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.DeleteCity](kamisama-modules-locations-features/kamisama-modules-locations-features-deletecity/index.md) - Provides the `DeleteCity` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.DeleteProvince](kamisama-modules-locations-features/kamisama-modules-locations-features-deleteprovince/index.md) - Provides the `DeleteProvince` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.FindCityById](kamisama-modules-locations-features/kamisama-modules-locations-features-findcitybyid/index.md) - Provides the `FindCityById` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.FindProvinceById](kamisama-modules-locations-features/kamisama-modules-locations-features-findprovincebyid/index.md) - Provides the `FindProvinceById` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.ListCities](kamisama-modules-locations-features/kamisama-modules-locations-features-listcities/index.md) - Provides the `ListCities` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.UpdateCity](kamisama-modules-locations-features/kamisama-modules-locations-features-updatecity/index.md) - Provides the `UpdateCity` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Features.UpdateProvince](kamisama-modules-locations-features/kamisama-modules-locations-features-updateprovince/index.md) - Provides the `UpdateProvince` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Repositories.Abstractions.ICityRepository](kamisama-modules-locations-repositories-abstractions/kamisama-modules-locations-repositories-abstractions-icityrepository/index.md) - Repository implementation or contract for `ICityRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Modules.Locations.Repositories.Abstractions.IProvinceRepository](kamisama-modules-locations-repositories-abstractions/kamisama-modules-locations-repositories-abstractions-iprovincerepository/index.md) - Repository implementation or contract for `IProvinceRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Modules.Locations.Repositories.Database.LocationsDbContext](kamisama-modules-locations-repositories-database/kamisama-modules-locations-repositories-database-locationsdbcontext/index.md) - Provides the `LocationsDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Repositories.Implementations.CityRepository](kamisama-modules-locations-repositories-implementations/kamisama-modules-locations-repositories-implementations-cityrepository/index.md) - Repository implementation or contract for `CityRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Modules.Locations.Repositories.Implementations.ProvinceRepository](kamisama-modules-locations-repositories-implementations/kamisama-modules-locations-repositories-implementations-provincerepository/index.md) - Repository implementation or contract for `ProvinceRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Modules.Locations.Services.ListCitiesByProvinceName](kamisama-modules-locations-services/kamisama-modules-locations-services-listcitiesbyprovincename/index.md) - Provides the `ListCitiesByProvinceName` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Locations.Services.ListProvinces](kamisama-modules-locations-services/kamisama-modules-locations-services-listprovinces/index.md) - Provides the `ListProvinces` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
