# KamiSama.Modules

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Composable ASP.NET Core modules that register services before application build and apply middleware or endpoints afterward. Use this package to assemble startup behavior in explicit module order through `ExtendedWebApplicationBuilder`.

## How to use

```shell
dotnet add package KamiSama.Modules --version 10.0.0
```

Wrap a standard builder, add modules in the required middleware and endpoint order, and finish with `BuildAsync`. All module service phases run first in insertion order, the application is built once, and then all application phases run in the same order:

```csharp
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
webBuilder.Services.AddAntiforgery(); // Required before AddAntiForgery.

var builder = webBuilder.Extend()
    .AddForwardedHeaders()
    .AddHttpsRedirection()
    .AddStaticFiles()
    .AddRouting(options => options.LowercaseUrls = true)
    .AddAuthorization()
    .AddAntiForgery()
    .AddControllers()
    .AddSwagger();

var app = await builder.BuildAsync(CancellationToken.None);
await app.RunAsync();
```

Module order is middleware and endpoint order during the post-build phase. A failure stops later modules, and a cancellation token is only passed to modules; most built-in modules ignore it. `Build` blocks on `BuildAsync(CancellationToken.None).Result`. `AntiForgeryModule` only calls `UseAntiforgery`, so register antiforgery services separately. **Do not add `ResponseCachingModule` in a runnable build:** its application phase always throws `NotImplementedException`, causing both build methods to fail after the underlying application has already been built.

## Namespaces

- [KamiSama.Modules](kamisama-modules/index.md) (37 types)

## Types

- [KamiSama.Modules.AntiForgeryExtension](kamisama-modules/kamisama-modules-antiforgeryextension/index.md) - Provides fluent registration of `AntiForgeryModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.AntiForgeryModule](kamisama-modules/kamisama-modules-antiforgerymodule/index.md) - Adds antiforgery middleware after build but does not register the required antiforgery services. Register them separately before adding this module.
- [KamiSama.Modules.AuthorizationExtension](kamisama-modules/kamisama-modules-authorizationextension/index.md) - Provides fluent registration of `AuthorizationModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.AuthorizationModule](kamisama-modules/kamisama-modules-authorizationmodule/index.md) - Registers authorization services before build and adds authorization middleware afterward. Its position in module order determines middleware order.
- [KamiSama.Modules.CascadingAuthenticationExtension](kamisama-modules/kamisama-modules-cascadingauthenticationextension/index.md) - Provides fluent registration of `CascadingAuthenticationModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.CascadingAuthenticationModule](kamisama-modules/kamisama-modules-cascadingauthenticationmodule/index.md) - Registers Blazor cascading authentication-state services before build. It performs no post-build application configuration.
- [KamiSama.Modules.ControllersModule](kamisama-modules/kamisama-modules-controllersmodule/index.md) - Registers MVC controllers, supports MVC-builder customization, and maps controller endpoints after build. Use the callback or a derived override to customize registration.
- [KamiSama.Modules.ControllersModuleExtension](kamisama-modules/kamisama-modules-controllersmoduleextension/index.md) - Provides fluent registration of `ControllersModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.CorsExtension](kamisama-modules/kamisama-modules-corsextension/index.md) - Provides fluent registration of `CorsModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.CorsModule](kamisama-modules/kamisama-modules-corsmodule/index.md) - Registers CORS options and adds inline-policy CORS middleware. Service options and middleware policy use separate callbacks.
- [KamiSama.Modules.CustomActionExtension](kamisama-modules/kamisama-modules-customactionextension/index.md) - Provides fluent synchronous and asynchronous custom post-build actions. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.CustomActionModule](kamisama-modules/kamisama-modules-customactionmodule/index.md) - Conditionally awaits a caller-provided application action during post-build configuration. It ignores the build cancellation token and registers no services.
- [KamiSama.Modules.ExtendedWebApplicationBuilder](kamisama-modules/kamisama-modules-extendedwebapplicationbuilder/index.md) - Composable wrapper around `WebApplicationBuilder` that collects web modules and applies them in a predictable build flow.
- [KamiSama.Modules.ForwardedHeadersExtension](kamisama-modules/kamisama-modules-forwardedheadersextension/index.md) - Provides fluent registration of `ForwardedHeadersModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ForwardedHeadersModule](kamisama-modules/kamisama-modules-forwardedheadersmodule/index.md) - Constructs forwarded-header options after build and adds the middleware. It does not register services during the first module phase.
- [KamiSama.Modules.HstsExtension](kamisama-modules/kamisama-modules-hstsextension/index.md) - Provides fluent registration of `HstsModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.HstsModule](kamisama-modules/kamisama-modules-hstsmodule/index.md) - Adds HSTS middleware after build with framework-configured options. It performs no service registration.
- [KamiSama.Modules.HttpsRedirectionExtension](kamisama-modules/kamisama-modules-httpsredirectionextension/index.md) - Provides fluent registration of `HttpsRedirectionModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.HttpsRedirectionModule](kamisama-modules/kamisama-modules-httpsredirectionmodule/index.md) - Adds HTTPS redirection middleware after build with framework-configured options. It performs no service registration.
- [KamiSama.Modules.RazorComponentExtension](kamisama-modules/kamisama-modules-razorcomponentextension/index.md) - Provides fluent registration and mapping of a root Razor component. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.RazorComponentModule<TRootComponent>](kamisama-modules/kamisama-modules-razorcomponentmodule-trootcomponent/index.md) - Registers Razor component services and maps the selected root component after build. The endpoint callback can add conventions to the mapped component.
- [KamiSama.Modules.RazorPagesModule](kamisama-modules/kamisama-modules-razorpagesmodule/index.md) - Registers configured Razor Pages services and maps page endpoints after build. Its endpoint mapping follows module insertion order.
- [KamiSama.Modules.RazorPagesModuleExtension](kamisama-modules/kamisama-modules-razorpagesmoduleextension/index.md) - Provides fluent registration of `RazorPagesModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.RequestLocalizationExtension](kamisama-modules/kamisama-modules-requestlocalizationextension/index.md) - Provides fluent request-localization module registration. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.RequestLocalizationModule](kamisama-modules/kamisama-modules-requestlocalizationmodule/index.md) - Registers localization and request-localization options before build, then adds request-localization middleware. The required callback defines provider and supported-culture behavior.
- [KamiSama.Modules.ResponseCachingExtension](kamisama-modules/kamisama-modules-responsecachingextension/index.md) - Provides fluent registration of the currently incomplete `ResponseCachingModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ResponseCachingModule](kamisama-modules/kamisama-modules-responsecachingmodule/index.md) - Registers response-caching services but always throws `NotImplementedException` during post-build configuration. Adding it causes both extended build methods to fail.
- [KamiSama.Modules.ResponseCompressionExtension](kamisama-modules/kamisama-modules-responsecompressionextension/index.md) - Provides fluent registration of `ResponseCompressionModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ResponseCompressionModule](kamisama-modules/kamisama-modules-responsecompressionmodule/index.md) - Registers configured response-compression services and adds compression middleware after build. Middleware position follows module insertion order.
- [KamiSama.Modules.RoutingExtension](kamisama-modules/kamisama-modules-routingextension/index.md) - Provides fluent registration of `RoutingModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.RoutingModule](kamisama-modules/kamisama-modules-routingmodule/index.md) - Registers route options and explicitly adds routing middleware after build. Add endpoint-producing modules in an order consistent with the intended pipeline.
- [KamiSama.Modules.StaticFileExtension](kamisama-modules/kamisama-modules-staticfileextension/index.md) - Provides fluent registration of `StaticFilesModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.StaticFilesModule](kamisama-modules/kamisama-modules-staticfilesmodule/index.md) - Maps ASP.NET Core static assets after build through `MapStaticAssets`. It does not add conventional static-file middleware.
- [KamiSama.Modules.SwaggerModule](kamisama-modules/kamisama-modules-swaggermodule/index.md) - Registers Swagger generation and exposes Swagger document and UI middleware in Development or when production exposure is enabled. Generation and UI use separate callbacks.
- [KamiSama.Modules.SwaggerModuleExtension](kamisama-modules/kamisama-modules-swaggermoduleextension/index.md) - Provides fluent registration of `SwaggerModule`. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.WebApplicationBuilderExtension](kamisama-modules/kamisama-modules-webapplicationbuilderextension/index.md) - Wraps a standard `WebApplicationBuilder` in an `ExtendedWebApplicationBuilder`. Wrapping alone does not register services or build the application.
- [KamiSama.Modules.WebModule](kamisama-modules/kamisama-modules-webmodule/index.md) - Base abstraction for modular ASP.NET Core setup. Implement it when a feature area needs to register services before build and apply middleware or endpoints after build.
