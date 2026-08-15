using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Net;

namespace KamiSama.Chassis.ProblemDetails;

/// <summary>
/// Configures the provider and localization behavior used by the ProblemDetails exception filter.
/// </summary>
public class KamiSamaProblemDetailsOptions
{
	/// <summary>
	/// Gets or sets the dependency-injection factory that creates the scoped conversion provider.
	/// </summary>
	public Func<IServiceProvider, IProblemDetailsDataProvider>? ProblemDetailsDataProviderFunc { get; set; }
	/// <summary>
	/// Gets or sets the factory that resolves the optional string localizer.
	/// </summary>
	public Func<IServiceProvider, IStringLocalizer?>? StringLocalizerFunc { get; set; }
	/// <summary>
	/// Gets or sets whether the default provider localizes message arguments before formatting the title.
	/// </summary>
	public bool LocalizeArguments { get; set; } = true;
	/// <summary>
	/// Selects <see cref="KamiSamaProblemDetailsProvider"/> and applies this instance's localization settings when it is resolved.
	/// </summary>
	/// <returns>This options instance for fluent configuration.</returns>
	public KamiSamaProblemDetailsOptions UseDefaultProblemDetailsProvider() => UseProblemDetailsProvider(sp =>
			{
				var provider = sp.GetRequiredService<KamiSamaProblemDetailsProvider>();
				var options = sp.GetRequiredService<KamiSamaProblemDetailsOptions>();

				if (options!.StringLocalizerFunc != null)
					provider.Localizer = options.StringLocalizerFunc(sp);
				provider.LocalizeArguments = options.LocalizeArguments;
				return provider;
			});
	/// <summary>
	/// Selects a custom provider factory for exception conversion.
	/// </summary>
	/// <param name="providerFunc">The factory invoked by dependency injection to create a scoped provider.</param>
	/// <returns>This options instance for fluent configuration.</returns>
	/// <remarks>Custom providers receive no automatic localization configuration; the factory must initialize any required provider properties.</remarks>
	public KamiSamaProblemDetailsOptions UseProblemDetailsProvider(Func<IServiceProvider, IProblemDetailsDataProvider> providerFunc)
	{
		this.ProblemDetailsDataProviderFunc = providerFunc;
		return this;
	}
	/// <summary>
	/// Configures a resource-based string localizer for the default provider.
	/// </summary>
	/// <typeparam name="ResourceType">The resource marker type used by <see cref="IStringLocalizerFactory"/>.</typeparam>
	/// <returns>This options instance for fluent configuration.</returns>
	public KamiSamaProblemDetailsOptions UseResourceLocalizer<ResourceType>()
	{
		this.StringLocalizerFunc = sp => sp.GetService<IStringLocalizerFactory>()?.Create(typeof(ResourceType));

		return this;

	}
}
