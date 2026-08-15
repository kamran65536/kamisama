---
name: KamiSama Libraries
description: Use when generating or reviewing code against the KamiSama.Extensions solution in this repository. This skill maps the public API surface of the KamiSama utility libraries, including extension helpers, repositories, dependency injection attributes, JSON/XML helpers, HTTP exceptions, problem-details plumbing, web modules, and generic chassis feature abstractions. Use it when you need the correct namespace, class/interface names, DTOs, and minimal usage patterns instead of rediscovering the libraries from source.
---

# KamiSama Libraries

Use this skill when code should integrate with the libraries in this repository instead of reimplementing the same utility patterns.

## Workflow

1. Identify the target area:
   - Core helpers, paging, crypto, Persian date/time, JSON, XML: read `references/core-and-serialization.md`
   - Generic repositories, EF/EF Core wrappers, JSON/XML file repositories: read `references/repositories.md`
   - HTTP exceptions, problem details, generic feature abstractions: read `references/chassis-and-features.md`
   - ASP.NET modular builder helpers: read `references/web-modules.md`
   - Dependency injection attributes, NLog, IranSystem, NSubstitute test builder: read `references/misc.md`
2. Reuse existing public APIs before adding new helpers.
3. Prefer the namespaces and usage patterns shown in the references.
4. When generating examples for users, keep them simple and directly aligned with the existing APIs.

## Guidance

- Treat the reference files as the source of truth for public APIs in this repository.
- Prefer extension methods from `KamiSama.Extensions` when they already cover the use case.
- Prefer async repository and feature APIs when available.
- For CRUD-style application services, compose from the chassis repository and feature abstractions before creating ad hoc service contracts.
- For ASP.NET apps, prefer `WebApplicationBuilder.Extend()` plus `Add*` web modules over inline middleware setup when the module exists.

## Important Caveats

- `KamiSama.Modules.ResponseCachingModule.ApplyConfigurationToAsync` currently throws `NotImplementedException`; do not assume it wires middleware.
- `KamiSama.Modules.OpenApiModule` is internal and effectively a placeholder; use `SwaggerModule` instead.
- Some exception status codes reflect the source code rather than conventional HTTP semantics:
  - `GoneException` returns `401`
  - `NotSupportedHttpException` returns `500`
- The XML repository implementations should be treated exactly as they exist in source; do not invent behaviors not present in the current code.

## Output Style

When you answer using this skill:

- Mention the exact namespace and type names.
- Prefer concise code examples that compile with the existing public API.
- If a DTO or search model is required, use the real types from these libraries, especially `SearchModel`, `PagedResult<T>`, `KamiSamaProblemDetailsOptions`, and `ConnectionStringOption`.
