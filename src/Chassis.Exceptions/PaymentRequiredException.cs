using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The original intention was that this code might be used as part of some form of digital cash or micropayment scheme.
/// </summary>
[ExcludeFromCodeCoverage]
public class PaymentRequiredException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status402PaymentRequired;
	/// <inheritdoc />
	public PaymentRequiredException()
	{
	}
	/// <inheritdoc />
	public PaymentRequiredException(string? message) : base(message)
	{
	}
	/// <inheritdoc />
	public PaymentRequiredException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}
