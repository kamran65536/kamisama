using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Localization.Features;

[AutoInjectScoped<IListAvailableCultures>]
public class ListAvailableCultures(IOptions<LocalizationOptions> options) : IListAvailableCultures
{
	public Task<CultureInfoDto[]> ListAsync(CancellationToken cancellationToken)
		=> Task.FromResult(options.Value.AvailableCultures ?? []);
}
