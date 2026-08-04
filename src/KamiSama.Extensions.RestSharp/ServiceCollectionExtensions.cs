using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace KamiSama.Extensions.RestSharp;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddKamiSamaRestSharp(this IServiceCollection services)
	{
		services.AddScoped<IRestClient>(sp => new RestClient(sp.GetRequiredService<HttpClient>()));
		services.AutoAddDependenciesFrom<RestBuilder>();
		return services;
	}
}
