using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;
/// <summary>
/// Indicates that the resource requested was previously in use but is no longer available and will not be available again.
/// </summary>
[ExcludeFromCodeCoverage]
public class GoneException : HttpExceptionBase
{
	/// <inheritdoc />
	public GoneException()
	{
	}
	/// <inheritdoc />
	public GoneException(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	public GoneException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status410Gone;
}
