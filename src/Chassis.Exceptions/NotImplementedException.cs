using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// Represents server functionality that is not implemented and should be reported with HTTP status code 501.
/// </summary>
[ExcludeFromCodeCoverage]
public class NotImplementedHttpException : HttpExceptionBase
{
    /// <summary>Gets HTTP status code 501.</summary>
    public override int StatusCode => 501;
    /// <summary>Initializes an exception using the exception type name as its localization key.</summary>
    public NotImplementedHttpException()
    {
    }
    /// <summary>Initializes an exception with a localization key and formatting arguments.</summary>
    /// <param name="message">The localization key, also used as the fallback message format.</param>
    /// <param name="args">Values used to format and later localize the message.</param>
    public NotImplementedHttpException(string message, params object?[] args) : base(message, args)
    {
    }
    /// <summary>Initializes an exception with localization metadata and an underlying exception.</summary>
    /// <param name="messageKey">The localization key, also used as the fallback message format.</param>
    /// <param name="args">Values used to format and later localize the message.</param>
    /// <param name="innerException">The exception that caused this failure, or <see langword="null"/>.</param>
    public NotImplementedHttpException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
}
