---
last-checked-utc: 2026-08-14T23:59:09Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.AntiForgeryExtension
  - KamiSama.Modules.AuthorizationExtension
  - KamiSama.Modules.CascadingAuthenticationExtension
  - KamiSama.Modules.ControllersModuleExtension
  - KamiSama.Modules.CorsExtension
  - KamiSama.Modules.CustomActionExtension
  - KamiSama.Modules.ForwardedHeadersExtension
  - KamiSama.Modules.HstsExtension
  - KamiSama.Modules.HttpsRedirectionExtension
  - KamiSama.Modules.RazorComponentExtension
  - KamiSama.Modules.RazorPagesModuleExtension
  - KamiSama.Modules.RequestLocalizationExtension
  - KamiSama.Modules.ResponseCachingExtension
  - KamiSama.Modules.ResponseCompressionExtension
  - KamiSama.Modules.RoutingExtension
  - KamiSama.Modules.StaticFileExtension
  - KamiSama.Modules.SwaggerModuleExtension
  - KamiSama.Modules.WebApplicationBuilderExtension
---

# Documentation Snapshot

The package description, public and protected API summaries, two-phase build ordering, middleware prerequisites, failure behavior, and example coverage were reviewed against the source at the recorded root version.

## Description

Composable ASP.NET Core modules that register services before application build and apply middleware or endpoints afterward.
Use this package to assemble startup behavior in explicit module order through `ExtendedWebApplicationBuilder`.

## How to use

```shell
dotnet add package KamiSama.Modules --version 10.0.0
```

Add modules in intended middleware and endpoint order, then call `BuildAsync`. Every `ConfigureServices` runs in insertion order before the underlying application is built; every `ApplyConfigurationToAsync` then runs in the same order. A failure stops later modules. `Build` blocks on the asynchronous flow with no cancellation token, and most built-in modules ignore the token supplied to `BuildAsync`.

`AntiForgeryModule` only calls `UseAntiforgery`; register antiforgery services separately before build. **`ResponseCachingModule` always throws `NotImplementedException` during its application phase, so adding it causes both `Build` and `BuildAsync` to fail after the underlying application has been built.**

## Example decisions

All 17 concrete public module classes have direct, full-name-matched class examples. `WebModule` and `ExtendedWebApplicationBuilder` retain pattern-level class examples. The 18 static extension classes listed in front matter are exempt from class-level examples because the package How-to demonstrates fluent composition and every extension method has an exact full-name-and-member example.
