using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Localization.Features;

/// <summary>
/// Validates a culture against configured metadata and appends ASP.NET Core's request-culture cookie to the active response.
/// The cookie affects culture selection on a later request and does not change the current request's culture.
/// </summary>
/// <param name="options">The bound localization options containing supported culture metadata.</param>
/// <param name="httpContextAccessor">The accessor used to obtain the active response; applications must register it with <c>AddHttpContextAccessor</c>.</param>
[AutoInjectScoped<ISetCulture>]
public class SetCulture(IOptions<LocalizationOptions> options, IHttpContextAccessor httpContextAccessor) : ISetCulture
{
    /// <summary>
    /// Finds a configured culture by case-insensitive name, requires an active HTTP context, and appends a request-culture cookie that expires in one year.
    /// </summary>
    /// <param name="culture">The supported culture name to persist. A <see langword="null"/> value is not handled and causes a null-reference failure.</param>
    /// <param name="cancellationToken">Ignored by this implementation.</param>
    /// <returns>The same configured metadata object selected for the cookie.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the culture is unsupported or no active HTTP context exists.</exception>
    public Task<CultureInfoDto> SetAsync(string culture, CancellationToken cancellationToken)
    {
        var availableCultures = options.Value.AvailableCultures ?? [];
        var selected = availableCultures.FirstOrDefault(x => x.Culture.ToLower() == culture.ToLower()) ?? throw new InvalidOperationException($"Culture '{culture}' is not supported.");

		var context = httpContextAccessor.HttpContext
            ?? throw new InvalidOperationException("No active HttpContext");

        context.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return Task.FromResult(selected);
    }
}
