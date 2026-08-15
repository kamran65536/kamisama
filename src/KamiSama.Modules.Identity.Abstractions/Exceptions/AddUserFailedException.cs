using KamiSama.Chassis.HttpExceptions;


namespace KamiSama.Modules.Identity.Exceptions;

/// <summary>
/// Represents an ASP.NET Core Identity user-creation failure and carries the first Identity error description as localization metadata.
/// The exception reports HTTP status 500 and does not expose the remaining Identity errors.
/// </summary>
/// <param name="reason">The first Identity error description, or <see langword="null"/> when no error was returned.</param>
public class AddUserFailedException(string? reason) : HttpExceptionBase(nameof(AddUserFailedException), reason)
{
    /// <summary>Gets the HTTP 500 status code used when user creation fails.</summary>
    public override int StatusCode => 500;
}
