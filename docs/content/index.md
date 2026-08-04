# KamiSama.Extensions

KamiSama.Extensions is a reusable .NET and ASP.NET Core package family for building modular applications. It includes core extension methods, dependency-injection helpers, JSON/XML serialization utilities, repository implementations, HTTP exception handling, ProblemDetails integration, web modules, external service integrations, and ready-made bounded-context modules such as Identity, Localization, Locations, and Ticketing.

Use these packages when you want shared infrastructure, feature-layer building blocks, and module wiring patterns across multiple services without copying the same plumbing into every project.

Version: `10.0.10`

## Package areas

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

## API documentation

- [Package index](api/index.md)
- [Symbol index](api/symbols.md)

## Packages

- [KamiSama.Chassis.Commons](api/chassis-commons/index.md) - Reusable feature and repository base classes for common CRUD-style application flows. Use this package when building service-layer features around entities, DTOs, repositories, and paged results.
- [KamiSama.Chassis.Commons.Abstractions](api/chassis-commons-abstractions/index.md) - Feature and repository contracts for the KamiSama chassis layer. Reference this package from application or module projects that need to depend on abstractions instead of concrete implementations.
- [KamiSama.Chassis.HttpExceptions](api/chassis-httpexceptions/index.md) - HTTP-oriented exception types with status codes, localization keys, and extra problem details. Use these exceptions to keep application errors consistent across ASP.NET Core APIs.
- [KamiSama.Chassis.ProblemDetails](api/chassis-problemdetails/index.md) - ASP.NET Core ProblemDetails integration for converting KamiSama HTTP exceptions into standardized API error responses.
- [KamiSama.Extensions.Core](api/extensions-core/index.md) - Core extension methods and paging models for common .NET tasks such as bytes, hex, base64, hashes, dates, streams, arrays, queues, and IQueryable paging.
- [KamiSama.Extensions.DependencyInjection](api/extensions-dependencyinjection/index.md) - Attribute-based dependency injection helpers for automatically registering services from assemblies. Use it to mark implementations with scoped, transient, or singleton service lifetimes.
- [KamiSama.Extensions.Logging](api/extensions-logging/index.md) - Logging abstractions and helpers used by KamiSama external service integrations.
- [KamiSama.Extensions.RestSharp](api/extensions-restsharp/index.md) - RestSharp registration and request helpers for KamiSama HTTP client integrations.
- [KamiSama.ExternalServices.Exceptions](api/externalservices-exceptions/index.md) - Shared exception types for external service integrations.
- [KamiSama.ExternalServices.Email.Abstractions](api/externalservices-email-abstractions/index.md) - Email service DTOs and feature contracts.
- [KamiSama.ExternalServices.Email.Core](api/externalservices-email-core/index.md) - Core email service registrations and shared email behavior.
- [KamiSama.ExternalServices.Email.Smtp](api/externalservices-email-smtp/index.md) - SMTP email service implementation and module registration.
- [KamiSama.ExternalServices.Sms.Abstractions](api/externalservices-sms-abstractions/index.md) - SMS service DTOs and feature contracts.
- [KamiSama.ExternalServices.Sms.Core](api/externalservices-sms-core/index.md) - Core SMS service registrations and shared SMS behavior.
- [KamiSama.ExternalServices.Sms.Kavenegar](api/externalservices-sms-kavenegar/index.md) - Kavenegar SMS provider implementation.
- [KamiSama.ExternalServices.Sms.NeoZarin](api/externalservices-sms-neozarin/index.md) - NeoZarin SMS provider implementation.
- [KamiSama.IranSystem](api/iransystem/index.md) - Iran System encoding conversion helpers for legacy Persian text interoperability. Use this package when integrating with systems that still exchange Iran System encoded data.
- [KamiSama.Extensions.Json](api/extensions-json/index.md) - JSON serialization and deserialization helpers for files, streams, byte arrays, and strings. Use it when application code needs compact System.Text.Json convenience methods.
- [KamiSama.Modules.Identity.Abstractions](api/modules-identity-abstractions/index.md) - Identity module request, response, and feature contracts for users, roles, password flows, and tokens.
- [KamiSama.Modules.Identity.Core](api/modules-identity-core/index.md) - ASP.NET Core Identity module implementation with users, roles, token handling, repositories, and web-module setup.
- [KamiSama.Modules.Identity.Postgresql](api/modules-identity-postgresql/index.md) - PostgreSQL provider registration for the KamiSama Identity module.
- [KamiSama.Modules.Identity.Sqlite](api/modules-identity-sqlite/index.md) - SQLite provider registration for the KamiSama Identity module.
- [KamiSama.Modules.Localization.Abstractions](api/modules-localization-abstractions/index.md) - Localization feature contracts and DTOs for culture selection.
- [KamiSama.Modules.Localization.Core](api/modules-localization-core/index.md) - Localization module implementation for available cultures, current culture, and request culture handling.
- [KamiSama.Modules.Locations.Abstractions](api/modules-locations-abstractions/index.md) - Locations module contracts and DTOs for provinces and cities.
- [KamiSama.Modules.Locations.Core](api/modules-locations-core/index.md) - Locations module implementation with province and city entities, repositories, features, and web-module setup.
- [KamiSama.Modules.Locations.Postgresql](api/modules-locations-postgresql/index.md) - PostgreSQL provider registration for the KamiSama Locations module.
- [KamiSama.Modules.Locations.Sqlite](api/modules-locations-sqlite/index.md) - SQLite provider registration for the KamiSama Locations module.
- [KamiSama.Modules.Ticketing.Abstractions](api/modules-ticketing-abstractions/index.md) - Ticketing module contracts and DTOs for tickets, comments, categories, attachments, status, and priority.
- [KamiSama.Modules.Ticketing.Core](api/modules-ticketing-core/index.md) - Ticketing module implementation with entities, repositories, feature services, and web-module setup.
- [KamiSama.Modules.Ticketing.Postgresql](api/modules-ticketing-postgresql/index.md) - PostgreSQL provider registration for the KamiSama Ticketing module.
- [KamiSama.Modules.Ticketing.Sqlite](api/modules-ticketing-sqlite/index.md) - SQLite provider registration for the KamiSama Ticketing module.
- [KamiSama.Extensions.NLog](api/extensions-nlog/index.md) - NLog integration helpers for configuring KamiSama logging with ASP.NET Core applications.
- [KamiSama.Repositories.Core](api/repositories-core/index.md) - Core repository interfaces, in-memory repository implementation, connection-string options, and database initialization contracts.
- [KamiSama.Repositories.EntityFramework](api/repositories-entityframework/index.md) - Repository implementation and paging helpers for classic Entity Framework projects.
- [KamiSama.Repositories.EntityFrameworkCore](api/repositories-entityframeworkcore/index.md) - Repository implementation, paging helpers, database initialization, and multi-provider DbContext registration for Entity Framework Core.
- [KamiSama.Repositories.EntityFrameworkCore.Postgresql](api/repositories-entityframeworkcore-postgresql/index.md) - PostgreSQL provider extension methods for Entity Framework Core multi-provider DbContext registration.
- [KamiSama.Repositories.EntityFrameworkCore.Sqlite](api/repositories-entityframeworkcore-sqlite/index.md) - SQLite provider extension methods for Entity Framework Core multi-provider DbContext registration.
- [KamiSama.Repositories.Json](api/repositories-json/index.md) - JSON-backed repository implementation for lightweight file-based persistence with synchronous and asynchronous repository APIs.
- [KamiSama.Repositories.Xml](api/repositories-xml/index.md) - XML-backed repository implementations for lightweight file or directory persistence with synchronous and asynchronous repository APIs.
- [KamiSama.Testing.NSubstitute](api/testing-nsubstitute/index.md) - DI-first testing helpers that auto-create NSubstitute mocks for missing constructor dependencies.
- [KamiSama.Extensions.WebModules](api/extensions-webmodules/index.md) - Modular ASP.NET Core application builder helpers for registering services and applying middleware through reusable web modules.
- [KamiSama.Extensions.Xml](api/extensions-xml/index.md) - XML serialization and deserialization helpers for files, streams, strings, and byte arrays. Use it when application code needs simple XML persistence or transport helpers.
