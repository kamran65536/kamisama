namespace Suma.AdminPanel.Services.Localization;

public interface IBizListAvailableCultures
{
	Task<BizCultureInfoDto[]> ListAsync(CancellationToken cancellationToken);
}
public interface IBizGetCurrentCulture
{
	Task<BizCultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken);
}

public interface IBizSetCulture
{
    Task<BizCultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken);
}
