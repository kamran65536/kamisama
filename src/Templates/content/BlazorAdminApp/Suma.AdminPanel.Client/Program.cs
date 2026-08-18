using KamiSama.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KamiSama.Modules.Commons.RestSharp;
using Suma.AdminPanel.Client.Utilities;
using System.Net.Http;

namespace Suma.AdminPanel.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();
        builder.Services.AddBlazorBootstrap();
        builder.Services.AddLocalization();
        builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddPolareumRestSharp();
        builder.Services.AddScoped<SafeRunner>();
        builder.Services.AutoAddDependenciesFrom<Program>();

        await builder.Build().RunAsync();
    }
}
