using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// he server either does not recognize the request method, or it lacks the ability to fulfil the request. 
/// </summary>
[ExcludeFromCodeCoverage]
public class NotImplementedHttpException : HttpExceptionBase
{
    /// <inheritdoc />
    public override int StatusCode => 501;
    /// <inheritdoc />
    public NotImplementedHttpException()
    {
    }
    /// <inheritdoc />
    public NotImplementedHttpException(string message, params object?[] args) : base(message, args)
    {
    }
    /// <inheritdoc />
    public NotImplementedHttpException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
}
