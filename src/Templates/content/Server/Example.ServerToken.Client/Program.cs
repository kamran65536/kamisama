using BlazorBootstrap;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.RestSharp;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Example.ServerToken.Client;

internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();
        builder.Services.AddBlazorBootstrap();
        builder.Services.AddLocalization();
        builder.Services.AddScoped(_ => new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
        });
        builder.Services.AddKamiSamaRestSharp();
        builder.Services.AutoAddDependenciesFrom<Program>();

        await builder.Build().RunAsync();
    }
}
