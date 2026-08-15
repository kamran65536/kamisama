namespace KamiSama.Modules.Localization.Features;

/// <summary>
/// Defines culture discovery without coupling callers to the ASP.NET Core localization implementation.
/// </summary>
public interface IListAvailableCultures
{
	/// <summary>
	/// Returns the cultures exposed by the implementation.
	/// </summary>
	/// <param name="cancellationToken">A token the implementation may observe while retrieving cultures.</param>
	/// <returns>The available culture metadata.</returns>
	Task<CultureInfoDto[]> ListAsync(CancellationToken cancellationToken);
}
/// <summary>
/// Defines lookup of the culture currently selected by the execution context.
/// </summary>
public interface IGetCurrentCulture
{
	/// <summary>
	/// Returns metadata for the current UI culture according to the implementation's matching and fallback rules.
	/// </summary>
	/// <param name="cancellationToken">A token the implementation may observe while resolving the current culture.</param>
	/// <returns>The current culture metadata.</returns>
	Task<CultureInfoDto> GetCurrentCultureAsync(CancellationToken cancellationToken);
}

/// <summary>
/// Defines selection of a supported culture for the current user or request context.
/// </summary>
public interface ISetCulture
{
	/// <summary>
	/// Selects the requested culture according to the implementation's validation and persistence behavior.
	/// </summary>
	/// <param name="culture">The culture name to select.</param>
	/// <param name="cancellationToken">A token the implementation may observe while selecting the culture.</param>
	/// <returns>The metadata for the selected culture.</returns>
    Task<CultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken);
}
