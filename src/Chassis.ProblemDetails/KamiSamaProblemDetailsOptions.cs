using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Net;

namespace KamiSama.Chassis.ProblemDetails;

/// <summary>
/// KamiSama Problem Details options
/// </summary>
public class KamiSamaProblemDetailsOptions
{
	/// <summary>
	/// Problem details provider factory function
	/// </summary>
	public Func<IServiceProvider, IProblemDetailsDataProvider>? ProblemDetailsDataProviderFunc { get; set; }
	/// <summary>
	/// String Localizer func
	/// </summary>
	public Func<IServiceProvider, IStringLocalizer?>? StringLocalizerFunc { get; set; }
	/// <summary>
	/// Uses <see cref="KamiSamaProblemDetailsProvider"/> as default Problem Details Provider
	/// </summary>
	/// <returns></returns>
	public KamiSamaProblemDetailsOptions UseDefaultProblemDetailsProvider() => UseProblemDetailsProvider(sp =>
			{
				var provider = sp.GetRequiredService<KamiSamaProblemDetailsProvider>();
				var options = sp.GetRequiredService<KamiSamaProblemDetailsOptions>();

				if (options!.StringLocalizerFunc != null)
					provider.Localizer = options.StringLocalizerFunc(sp);

				return provider;
			});
	/// <summary>
	/// Uses customer provider as Problem Details Provider
	/// </summary>
	/// <param name="providerFunc"></param>
	/// <returns></returns>
	public KamiSamaProblemDetailsOptions UseProblemDetailsProvider(Func<IServiceProvider, IProblemDetailsDataProvider> providerFunc)
	{
		this.ProblemDetailsDataProviderFunc = providerFunc;
		return this;
	}
	///// <summary>
	///// Uses Resource String Localizer
	///// </summary>
	///// <returns></returns>
	//public KamiSamaProblemDetailsOptions UseResourceLocalizer(string typeName, string assemblyName)
	//{
	//	this.StringLocalizerFunc = sp => sp.GetRequiredService<IStringLocalizerFactory>().Create(typeName, assemblyName);

	//	return this;
	//}
	/// <summary>
	/// Uses Resource String Localizer
	/// </summary>
	/// <typeparam name="ResourceType"></typeparam>
	/// <returns></returns>
	public KamiSamaProblemDetailsOptions UseResourceLocalizer<ResourceType>()
	{
		this.StringLocalizerFunc = sp => sp.GetService<IStringLocalizerFactory>()?.Create(typeof(ResourceType));

		return this;

	}
}
