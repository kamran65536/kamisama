using Example.Bootstrap;
using Example.Core;
using KamiSama.Modules;
using Microsoft.AspNetCore.Authentication.Cookies;

var webBuilder = WebApplication.CreateBuilder(args);
webBuilder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
webBuilder.Services.AddAuthorization();

var builder = webBuilder
    .Extend()
    .AddModule<PlatformModule>()
    .AddControllers()
    .AddPlatformModules(webBuilder.Configuration, registerIdentity: true, useJwtAuth: false);

var app = await builder.BuildAsync(CancellationToken.None);
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapFallbackToFile("index.html");
await app.RunAsync();
