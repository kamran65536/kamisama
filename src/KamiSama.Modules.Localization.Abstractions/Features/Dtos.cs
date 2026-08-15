namespace KamiSama.Modules.Localization.Features;

/// <summary>
/// Carries display text, flag representation, and a .NET culture name between localization callers and implementations.
/// </summary>
/// <param name="DisplayName">The human-readable culture label.</param>
/// <param name="RepresentedFlag">The application-defined flag code or representation.</param>
/// <param name="Culture">The culture name used to construct or compare <see cref="System.Globalization.CultureInfo"/> values.</param>
public record CultureInfoDto(string DisplayName, string RepresentedFlag, string Culture);
