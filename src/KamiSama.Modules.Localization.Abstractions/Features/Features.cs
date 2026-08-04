namespace KamiSama.Modules.Localization.Features;

public interface IListAvailableCultures
{
	Task<CultureInfoDto[]> ListAsync(CancellationToken cancellationToken);
}
public interface IGetCurrentCulture
{
	Task<CultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken);
}

public interface ISetCulture
{
    Task<CultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken);
}