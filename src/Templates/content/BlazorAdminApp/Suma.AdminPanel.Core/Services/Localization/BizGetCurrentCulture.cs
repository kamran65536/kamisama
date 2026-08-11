using Polareum.Localization.Features;

namespace Suma.AdminPanel.Services.Localization;

[AutoInjectScoped<IBizGetCurrentCulture>]
internal class BizGetCurrentCulture(
	ILogger<BizGetCurrentCulture> logger,
	IGetCurrentCulture getCurrentCulture) : IBizGetCurrentCulture
{
	public async Task<BizCultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			return (await getCurrentCulture.GetCurrentCultureAsync(cancellationToken)).ToBizDto();
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to get the current culture.");
			throw;
		}
	}
}
