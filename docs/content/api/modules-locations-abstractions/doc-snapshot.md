---
last-checked-utc: 2026-08-15T00:26:43Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.Locations.Features.AddCityRequest
  - KamiSama.Modules.Locations.Features.AddProvinceRequest
  - KamiSama.Modules.Locations.Features.CityDto
  - KamiSama.Modules.Locations.Features.CitySearchModel
  - KamiSama.Modules.Locations.Features.ProvinceDto
  - KamiSama.Modules.Locations.Features.ProvinceSearchModel
  - KamiSama.Modules.Locations.Features.UpdateCityRequest
  - KamiSama.Modules.Locations.Features.UpdateProvinceRequest
---

# Documentation Snapshot

The package description, all public contract and data summaries, Core-compatible feature examples, query-shaping caveats, publication mismatch, and exact example exemptions were reviewed against the source at the recorded root version.

## Description

Provider-neutral province and city feature contracts, requests, DTOs, and paging search models.
Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet exposed `10.0.11` as the latest package when reviewed; `10.0.0` itself was not available.

```shell
dotnet add package KamiSama.Modules.Locations.Abstractions --version 10.0.0
```

Inject feature interfaces into application services or controllers after an implementation such as Core has registered them. This package alone registers no services, persistence, controllers, endpoints, validation pipeline, authentication, or authorization. Core's city list supports city-name and province-name substrings, an exact province id, and `province` ordering; province lists always order by name. Alternative implementations are not required to preserve those query details.

## Example decisions

Every feature interface has an exact-full-name class example showing a DI-resolved operation. The exact full names listed in `classes-without-examples` are simple request, DTO, or search records whose constructor and member documentation describes their complete data shape, so separate class examples are not useful.
