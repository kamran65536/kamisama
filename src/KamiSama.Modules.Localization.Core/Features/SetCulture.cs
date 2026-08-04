using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Localization.Features;

[AutoInjectScoped<ISetCulture>]
public class SetCulture(IOptions<LocalizationOptions> options, IHttpContextAccessor httpContextAccessor) : ISetCulture
{
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
