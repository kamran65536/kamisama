using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The request was well-formed but was unable to be followed due to semantic errors.
/// </summary>
public class UnProcessableEntityException : HttpExceptionBase
{
    /// <inheritdoc />
    public override int StatusCode => StatusCodes.Status422UnprocessableEntity;
    /// <inheritdoc />
    public UnProcessableEntityException()
    {
    }
    /// <inheritdoc />
    public UnProcessableEntityException(string? message) : base(message)
    {
    }
    /// <inheritdoc />
    public UnProcessableEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
    /// <inheritdoc />
    public UnProcessableEntityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
