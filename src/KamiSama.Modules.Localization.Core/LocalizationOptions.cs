using Microsoft.Extensions.Configuration;
using KamiSama.Modules.Localization.Features;

namespace KamiSama.Modules.Localization;

/// <summary>
/// Defines the supported culture metadata and fallback culture bound by <see cref="LocalizationModule"/>.
/// Arrays are stored and returned directly, so callers can mutate the configured collection.
/// </summary>
public class LocalizationOptions
{
	/// <summary>
	/// Gets or sets the mutable culture metadata bound from <c>available-cultures</c>. The default contains United States English.
	/// </summary>
	[ConfigurationKeyName("available-cultures")]
	public CultureInfoDto[] AvailableCultures { get; set; } = [new ("English (United States)", "en-US", "en-US")];

	/// <summary>
	/// Gets or sets the fallback culture name bound from <c>default-culture</c>. The value must be accepted by <see cref="System.Globalization.CultureInfo"/> when the module is added.
	/// </summary>
	[ConfigurationKeyName("default-culture")]
	public string DefaultCulture { get; set; } = "en-US";
}
