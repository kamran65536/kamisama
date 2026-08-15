using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace KamiSama.Extensions.RestSharp;

/// <summary>
/// Registers the RestSharp client and fluent request builder used by this package.
/// Call this during service configuration after making <see cref="HttpClient"/> available from dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers <see cref="IRestClient"/> and <see cref="IRestBuilder"/> as scoped services.
	/// </summary>
	/// <param name="services">The service collection that receives the RestSharp registrations.</param>
	/// <returns>The same service collection so additional registrations can be chained.</returns>
	public static IServiceCollection AddKamiSamaRestSharp(this IServiceCollection services)
	{
		services.AddScoped<IRestClient>(sp => new RestClient(sp.GetRequiredService<HttpClient>()));
		services.AutoAddDependenciesFrom<RestBuilder>();
		return services;
	}
}
