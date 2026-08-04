
using Microsoft.Extensions.Options;
using System.Globalization;

namespace KamiSama.Modules.Localization.Features;

[AutoInjectScoped<IGetCurrentCulture>]
public class GetCurrentCulture(IOptions<LocalizationOptions> options) : IGetCurrentCulture
{
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
