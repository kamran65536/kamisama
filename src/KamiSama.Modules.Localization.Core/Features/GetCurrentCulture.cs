
using Microsoft.Extensions.Options;
using System.Globalization;

namespace KamiSama.Modules.Localization.Features;

/// <summary>
/// Maps <see cref="CultureInfo.CurrentUICulture"/> to configured culture metadata, falling back from a neutral current culture to the configured default.
/// </summary>
/// <param name="options">The bound localization options used for matching and neutral-culture fallback.</param>
[AutoInjectScoped<IGetCurrentCulture>]
public class GetCurrentCulture(IOptions<LocalizationOptions> options) : IGetCurrentCulture
{
	/// <summary>
	/// Resolves the current UI culture synchronously, matches it by culture name using current-culture-insensitive comparison, and synthesizes metadata when no configured entry matches.
	/// </summary>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>The matched configured object, or synthesized metadata for the resolved current UI culture.</returns>
	public Task<CultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken)
	{
		var currentCulture = CultureInfo.CurrentUICulture;
		
		if (currentCulture.IsNeutralCulture)
			currentCulture = new CultureInfo(options.Value.DefaultCulture);

		var cultures = options.Value.AvailableCultures ?? [];

		var selected = cultures.FirstOrDefault(x => x.Culture.Equals(currentCulture.Name, StringComparison.CurrentCultureIgnoreCase)) ?? new CultureInfoDto(currentCulture.DisplayName, currentCulture.Name, currentCulture.Name);

		return Task.FromResult(selected);
	}
}
