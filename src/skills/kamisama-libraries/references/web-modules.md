# `KamiSama.Modules`

## `KamiSama.Modules`

### `WebModule`
Base abstraction for modular ASP.NET configuration.

### `ConfigureServices(IServiceCollection services)`
Registers services before the app is built.

### `ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)`
Applies middleware or endpoint configuration after the app is built.

```csharp
using KamiSama.Modules;

public sealed class MyModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services) {}
    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken) => Task.CompletedTask;
}
```

## `KamiSama.Modules`

### `ExtendedWebApplicationBuilder`
Composable wrapper around `WebApplicationBuilder` that accumulates `WebModule` instances.

### `AddModule(WebModule module)`
Registers a module instance.

### `AddModule<TModule>()`
Registers a parameterless module type.

### `Add(Action<WebApplication> action, bool condition = true)`
Adds an inline synchronous post-build action.

### `Add(Func<WebApplication, Task> action, bool condition = true)`
Adds an inline async post-build action.

### `ConfigureServices(Action<IServiceCollection> configure)`
Applies service registration directly.

### `BuildAsync(CancellationToken cancellationToken)`
Builds the app after applying all modules.

### `Build()`
Synchronous wrapper over `BuildAsync`.

```csharp
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args)
    .Extend()
    .AddControllers()
    .AddSwagger();

var app = await builder.BuildAsync(CancellationToken.None);
```

## `KamiSama.Modules`

### `WebApplicationBuilderExtension`
Entry point for the modular builder.

### `Extend(this WebApplicationBuilder builder)`
Wraps a standard builder as `ExtendedWebApplicationBuilder`.

```csharp
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args).Extend();
```

## `KamiSama.Modules`

### `ControllersModule`
Adds MVC controllers and maps them.

### `ConfigureServices`
Calls `services.AddControllers()`.

### `ApplyConfigurationToAsync`
Calls `app.MapControllers()`.

### `ControllersModuleExtension.AddControllers`
Convenience extension for the module.

```csharp
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args).Extend().AddControllers();
```

## `KamiSama.Modules`

### `SwaggerModule`
Adds Swagger generation and Swagger UI.

### `ConfigureServices`
Registers endpoint explorer and Swagger generation.

### `ApplyConfigurationToAsync`
Enables Swagger middleware in development or optionally production.

### `SwaggerModuleExtension.AddSwagger`
Convenience extension for the module.

```csharp
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args)
    .Extend()
    .AddSwagger(addEndPointInProduction: true);
```

## `KamiSama.Modules`

### `CorsModule`
Adds CORS services and middleware.

### `ConfigureServices`
Registers CORS options.

### `ApplyConfigurationToAsync`
Calls `app.UseCors(...)`.

### `CorsExtension.AddCors`
Convenience extension for the module.

```csharp
using KamiSama.Modules;

builder.AddCors(configurePolicy: policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
```

## `KamiSama.Modules`

### `AuthorizationModule`
Adds authorization services and middleware.

### `AuthorizationExtension.AddAuthorization`
Convenience extension for the module.

```csharp
builder.AddAuthorization();
```

## `KamiSama.Modules`

### `AntiForgeryModule`
Applies antiforgery middleware.

### `AntiForgeryExtension.AddAntiForgery`
Convenience extension for the module.

```csharp
builder.AddAntiForgery();
```

## `KamiSama.Modules`

### `CascadingAuthenticationModule`
Registers Blazor cascading authentication state.

### `CascadingAuthenticationExtension.AddCascadingAuthentication`
Convenience extension for the module.

```csharp
builder.AddCascadingAuthentication();
```

## `KamiSama.Modules`

### `CustomActionModule`
Runs a custom action after the app is built.

### `ApplyConfigurationToAsync`
Executes the supplied action when `condition` is `true`.

### `CustomActionExtension.AddAction`
Convenience extensions for sync and async custom actions.

```csharp
builder.AddAction(app => app.MapGet("/health", () => Results.Ok()));
```

## `KamiSama.Modules`

### `ForwardedHeadersModule`
Applies forwarded headers middleware.

### `ForwardedHeadersExtension.AddForwardedHeaders`
Convenience extension for the module.

```csharp
builder.AddForwardedHeaders(options => options.ForwardedHeaders = ForwardedHeaders.All);
```

## `KamiSama.Modules`

### `HstsModule`
Applies HSTS middleware.

### `HstsExtension.AddHsts`
Convenience extension for the module.

```csharp
builder.AddHsts();
```

## `KamiSama.Modules`

### `HttpsRedirectionModule`
Applies HTTPS redirection middleware.

### `HttpsRedirectionExtension.AddHttpsRedirection`
Convenience extension for the module.

```csharp
builder.AddHttpsRedirection();
```

## `KamiSama.Modules`

### `RazorComponentModule<TRootComponent>`
Registers Razor components and maps the root component.

### `RazorComponentExtension.AddRazorComponents<TRootComponent>`
Convenience extension for the module.

```csharp
builder.AddRazorComponents<App>();
```

## `KamiSama.Modules`

### `RazorPagesModule`
Registers Razor Pages and maps them.

### `RazorPagesModuleExtension.AddRazorPages`
Convenience extension for the module.

```csharp
builder.AddRazorPages(options => { });
```

## `KamiSama.Modules`

### `RequestLocalizationModule`
Adds localization services and request localization middleware.

### `RequestLocalizationExtension.AddRequestLocalization(Action<RequestLocalizationOptions> configure)`
Registers with explicit options.

### `RequestLocalizationExtension.AddRequestLocalization(RequestCulture defaultCulture, params CultureInfo[] supportedCultures)`
Registers a common default-culture setup.

```csharp
using Microsoft.AspNetCore.Localization;
using System.Globalization;

builder.AddRequestLocalization(new RequestCulture("fa-IR"), new CultureInfo("fa-IR"), new CultureInfo("en-US"));
```

## `KamiSama.Modules`

### `ResponseCompressionModule`
Registers response compression and applies middleware.

### `ResponseCompressionExtension.AddResponseCompression`
Convenience extension for the module.

```csharp
builder.AddResponseCompression();
```

## `KamiSama.Modules`

### `ResponseCachingModule`
Registers response caching options but currently throws `NotImplementedException` during apply.

### `ResponseCachingExtension.AddResponseCaching`
Convenience extension for the module.

```csharp
builder.AddResponseCaching();
```

## `KamiSama.Modules`

### `RoutingModule`
Registers route options and applies `UseRouting()`.

### `RoutingExtension.AddRouting`
Convenience extension for the module.

```csharp
builder.AddRouting(options => options.LowercaseUrls = true);
```

## `KamiSama.Modules`

### `StaticFilesModule`
Maps static assets.

### `StaticFileExtension.AddStaticFiles`
Convenience extension for the module.

```csharp
builder.AddStaticFiles();
```
