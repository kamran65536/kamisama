using Microsoft.AspNetCore.Http;
using System;

namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// Indicates that the resource requested was previously in use but is no longer available and will not be available again.
/// </summary>
public class GoneException : HttpExceptionBase
{
    /// <inheritdoc />
    public GoneException()
    {
    }
    /// <inheritdoc />
    public GoneException(string message, params object?[] args) : base(message, args)
    {
    }
    /// <inheritdoc />
    public GoneException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
    {
    }
    /// <inheritdoc />
    public override int StatusCode => StatusCodes.Status410Gone;
}
