using Polareum.Localization.Features;

namespace Suma.AdminPanel.Services.Localization;

[AutoInjectScoped<IBizListAvailableCultures>]
internal class BizListAvailableCultures(
	ILogger<BizListAvailableCultures> logger,
	IListAvailableCultures listAvailableCultures) : IBizListAvailableCultures
{
	public async Task<BizCultureInfoDto[]> ListAsync(CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var result = await listAvailableCultures.ListAsync(cancellationToken);

			return [.. result.Select(x => x.ToBizDto())];
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to list available cultures.");
			throw;
		}
	}
}
