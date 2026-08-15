# KamiSama.Extensions

KamiSama.Extensions is a reusable .NET and ASP.NET Core package family for building modular applications. It includes core extension methods, dependency-injection helpers, JSON/XML serialization utilities, repository implementations, HTTP exception handling, ProblemDetails integration, web modules, external service integrations, and ready-made bounded-context modules such as Identity, Localization, Locations, and Ticketing.

Use these packages when you want shared infrastructure, feature-layer building blocks, and module wiring patterns across multiple services without copying the same plumbing into every project.

Current documented version: `10.0.10`

## Documentation

- [Documentation home](docs/content/index.md)
- [Package index](docs/content/api/index.md)
- [Symbol index](docs/content/api/symbols.md)

Build the documentation locally from the `docs` folder:

```shell
python -m mkdocs build --strict
```

## Package Areas

| Area | What it provides |
| --- | --- |
| Core extensions | Byte, string, date, hash, stream, collection, conversion, and paging helpers. |
| Dependency injection | Attribute-based service registration and assembly scanning. |
| Serialization | JSON and XML helpers for strings, streams, bytes, files, and repositories. |
| Repositories | In-memory, JSON, XML, EF, and EF Core repository patterns and paging support. |
| Chassis | Base classes and contracts for CRUD-style feature services and HTTP-aware errors. |
| Web modules | Modular ASP.NET Core service and middleware registration. |
| External services | Email and SMS abstractions plus SMTP, Kavenegar, and NeoZarin integrations. |
| Application modules | Identity, Localization, Locations, and Ticketing bounded contexts. |

## Packages

| Package | What it provides | Install |
| --- | --- | --- |
| [KamiSama.Extensions.Core](docs/content/api/extensions-core/index.md) | Core extension methods and paging models for common .NET tasks. | `dotnet add package KamiSama.Extensions.Core --version 10.0.10` |
| [KamiSama.Extensions.DependencyInjection](docs/content/api/extensions-dependencyinjection/index.md) | Attribute-based dependency injection helpers for automatic service registration. | `dotnet add package KamiSama.Extensions.DependencyInjection --version 10.0.10` |
| [KamiSama.Extensions.Json](docs/content/api/extensions-json/index.md) | JSON serialization and deserialization helpers. | `dotnet add package KamiSama.Extensions.Json --version 10.0.10` |
| [KamiSama.Extensions.Xml](docs/content/api/extensions-xml/index.md) | XML serialization and deserialization helpers. | `dotnet add package KamiSama.Extensions.Xml --version 10.0.10` |
| [KamiSama.Modules](docs/content/api/modules/index.md) | Modular ASP.NET Core service and middleware registration. | `dotnet add package KamiSama.Modules --version 10.0.10` |
| [KamiSama.Chassis.Commons](docs/content/api/chassis-commons/index.md) | Reusable feature and repository base classes for CRUD-style application flows. | `dotnet add package KamiSama.Chassis.Commons --version 10.0.10` |
| [KamiSama.Chassis.Commons.Abstractions](docs/content/api/chassis-commons-abstractions/index.md) | Feature and repository contracts for chassis-based application services. | `dotnet add package KamiSama.Chassis.Commons.Abstractions --version 10.0.10` |
| [KamiSama.Chassis.HttpExceptions](docs/content/api/chassis-httpexceptions/index.md) | HTTP-aware exception types with status codes and localization metadata. | `dotnet add package KamiSama.Chassis.HttpExceptions --version 10.0.10` |
| [KamiSama.Chassis.ProblemDetails](docs/content/api/chassis-problemdetails/index.md) | ASP.NET Core ProblemDetails integration for KamiSama exceptions. | `dotnet add package KamiSama.Chassis.ProblemDetails --version 10.0.10` |
| [KamiSama.Repositories.Core](docs/content/api/repositories-core/index.md) | Core repository interfaces, in-memory repository, and initialization contracts. | `dotnet add package KamiSama.Repositories.Core --version 10.0.10` |
| [KamiSama.Repositories.EntityFramework](docs/content/api/repositories-entityframework/index.md) | Repository implementation and paging helpers for classic Entity Framework. | `dotnet add package KamiSama.Repositories.EntityFramework --version 10.0.10` |
| [KamiSama.Repositories.EntityFrameworkCore](docs/content/api/repositories-entityframeworkcore/index.md) | EF Core repositories, paging, initialization, and multi-provider DbContext setup. | `dotnet add package KamiSama.Repositories.EntityFrameworkCore --version 10.0.10` |
| [KamiSama.Repositories.Json](docs/content/api/repositories-json/index.md) | JSON-backed file repository implementation. | `dotnet add package KamiSama.Repositories.Json --version 10.0.10` |
| [KamiSama.Repositories.Xml](docs/content/api/repositories-xml/index.md) | XML-backed file and directory repository implementations. | `dotnet add package KamiSama.Repositories.Xml --version 10.0.10` |
| [KamiSama.ExternalServices.Email.Core](docs/content/api/externalservices-email-core/index.md) | Core email service registration and behavior. | `dotnet add package KamiSama.ExternalServices.Email.Core --version 10.0.10` |
| [KamiSama.ExternalServices.Email.Smtp](docs/content/api/externalservices-email-smtp/index.md) | SMTP email service implementation. | `dotnet add package KamiSama.ExternalServices.Email.Smtp --version 10.0.10` |
| [KamiSama.ExternalServices.Sms.Core](docs/content/api/externalservices-sms-core/index.md) | Core SMS service registration and behavior. | `dotnet add package KamiSama.ExternalServices.Sms.Core --version 10.0.10` |
| [KamiSama.ExternalServices.Sms.Kavenegar](docs/content/api/externalservices-sms-kavenegar/index.md) | Kavenegar SMS provider implementation. | `dotnet add package KamiSama.ExternalServices.Sms.Kavenegar --version 10.0.10` |
| [KamiSama.ExternalServices.Sms.NeoZarin](docs/content/api/externalservices-sms-neozarin/index.md) | NeoZarin SMS provider implementation. | `dotnet add package KamiSama.ExternalServices.Sms.NeoZarin --version 10.0.10` |
| [KamiSama.Modules.Identity.Core](docs/content/api/modules-identity-core/index.md) | ASP.NET Core Identity module implementation. | `dotnet add package KamiSama.Modules.Identity.Core --version 10.0.10` |
| [KamiSama.Modules.Localization.Core](docs/content/api/modules-localization-core/index.md) | Localization module implementation. | `dotnet add package KamiSama.Modules.Localization.Core --version 10.0.10` |
| [KamiSama.Modules.Locations.Core](docs/content/api/modules-locations-core/index.md) | Locations module implementation for provinces and cities. | `dotnet add package KamiSama.Modules.Locations.Core --version 10.0.10` |
| [KamiSama.Modules.Ticketing.Core](docs/content/api/modules-ticketing-core/index.md) | Ticketing module implementation for tickets, comments, categories, and attachments. | `dotnet add package KamiSama.Modules.Ticketing.Core --version 10.0.10` |
| [KamiSama.Extensions.NLog](docs/content/api/extensions-nlog/index.md) | NLog integration helpers. | `dotnet add package KamiSama.Extensions.NLog --version 10.0.10` |
| [KamiSama.Extensions.RestSharp](docs/content/api/extensions-restsharp/index.md) | RestSharp registration and request helpers. | `dotnet add package KamiSama.Extensions.RestSharp --version 10.0.10` |
| [KamiSama.IranSystem](docs/content/api/iransystem/index.md) | Iran System encoding conversion helpers for legacy Persian systems. | `dotnet add package KamiSama.IranSystem --version 10.0.10` |
| [KamiSama.Testing.NSubstitute](docs/content/api/testing-nsubstitute/index.md) | DI-first testing helpers that auto-create NSubstitute mocks. | `dotnet add package KamiSama.Testing.NSubstitute --version 10.0.10` |

Provider-specific packages for PostgreSQL and SQLite, plus abstraction-only packages for modules and external services, are listed in the full [package index](docs/content/api/index.md).
