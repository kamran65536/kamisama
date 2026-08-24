using Example.ServerToken;
//#if (IncludeClient)
using Example.ServerToken.Components;
using BlazorBootstrap;
//#endif
using KamiSama.Modules;
//#if (HasBootstrap)
using Example.Bootstrap;
//#endif

var webBuilder = WebApplication.CreateBuilder(args);
webBuilder.Services.AddAntiforgery();
//#if (IncludeClient)
var components = webBuilder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddAuthenticationStateSerialization();
components.AddInteractiveWebAssemblyComponents();
webBuilder.Services.AddCascadingAuthenticationState();
webBuilder.Services.AddBlazorBootstrap();
//#endif

var builder = webBuilder
    .Extend()
    .AddModule<ServerTokenModule>();
//#if (HasBootstrap)
builder.AddBootstrap();
//#endif
builder
    .AddControllers()
    .AddAuthorization()
    .AddHttpsRedirection()
    .AddAntiForgery()
    .AddStaticFiles();

var app = await builder.BuildAsync(CancellationToken.None);

//#if (IncludeClient)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Example.ServerToken.Client.ClientAssemblyMarker).Assembly);
//#endif

await app.RunAsync();
