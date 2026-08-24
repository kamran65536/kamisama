# Web Modules Snapshot

Start modular ASP.NET applications with `WebApplication.CreateBuilder(args).Extend()` from `KamiSama.Modules`, add modules, then call `BuildAsync`.

Available modules include controllers, Swagger, CORS, authorization, antiforgery, cascading authentication, forwarded headers, HSTS, HTTPS redirection, Razor components, Razor Pages, request localization, response compression, routing, and static files.

Verify extension signatures before use. `ResponseCachingModule` currently throws while applying configuration, and `OpenApiModule` is an internal placeholder; use `SwaggerModule`.
