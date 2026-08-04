using Microsoft.Extensions.Configuration;
using KamiSama.Modules.Localization.Features;

namespace KamiSama.Modules.Localization;

public class LocalizationOptions
{
	[ConfigurationKeyName("available-cultures")]
	public CultureInfoDto[] AvailableCultures { get; set; } = [new ("English (United States)", "en-US", "en-US")];

	[ConfigurationKeyName("default-culture")]
	public string DefaultCulture { get; set; } = "en-US";
}
