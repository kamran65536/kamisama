using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing).
/// </summary>
public class BadRequestException : HttpExceptionBase
{
    /// <inheritdoc />
    public override int StatusCode => StatusCodes.Status400BadRequest;

    /// <inheritdoc />
    public BadRequestException()
    {
    }
    /// <inheritdoc />
    public BadRequestException(string? message) : base(message)
    {
    }
    /// <inheritdoc />
    public BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
    /// <inheritdoc />
    public BadRequestException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
 }
