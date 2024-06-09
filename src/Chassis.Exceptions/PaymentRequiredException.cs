using Microsoft.AspNetCore.Http;
using System;

namespace KamiSama.Chassis.HttpExceptions;

/// <summary>
/// The original intention was that this code might be used as part of some form of digital cash or micropayment scheme.
/// </summary>
public class PaymentRequiredException : HttpExceptionBase
{
	/// <inheritdoc />
	public override int StatusCode => StatusCodes.Status402PaymentRequired;
	/// <inheritdoc />
	public PaymentRequiredException()
	{
	}
	/// <inheritdoc />
	public PaymentRequiredException(string messageKey, params object?[] args) : base(messageKey, args)
	{
	}
	/// <inheritdoc />
	public PaymentRequiredException(string messageKey, object?[] args, Exception? innerException) : base(messageKey, args, innerException)
	{
	}
}
