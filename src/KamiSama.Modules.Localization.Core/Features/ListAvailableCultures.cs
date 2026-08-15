using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Localization.Features;

/// <summary>
/// Returns the configured culture metadata from the options instance without copying the array.
/// </summary>
/// <param name="options">The bound localization options.</param>
[AutoInjectScoped<IListAvailableCultures>]
public class ListAvailableCultures(IOptions<LocalizationOptions> options) : IListAvailableCultures
{
	/// <summary>
	/// Returns the mutable configured array, or a new empty array when the configured value is <see langword="null"/>; no asynchronous work is performed.
	/// </summary>
	/// <param name="cancellationToken">Ignored by this implementation.</param>
	/// <returns>The configured array instance or an empty array.</returns>
	public Task<CultureInfoDto[]> ListAsync(CancellationToken cancellationToken)
		=> Task.FromResult(options.Value.AvailableCultures ?? []);
}
