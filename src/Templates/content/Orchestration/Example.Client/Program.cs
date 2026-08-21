using Example.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
//#if (UserManagement)
builder.Services.AddScoped<Example.Abstractions.IListAdminUsers, Example.Client.Services.Users.UsersProxy>();
//#endif
//#if (Ticketing)
builder.Services.AddScoped<Example.Abstractions.IListAdminTickets, Example.Client.Services.Tickets.TicketsProxy>();
//#endif
await builder.Build().RunAsync();
