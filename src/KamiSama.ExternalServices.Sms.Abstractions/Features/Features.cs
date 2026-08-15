namespace KamiSama.ExternalServices.Sms.Features;

/// <summary>
/// Defines the provider-neutral operation for sending an SMS message.
/// Implement it in an SMS provider package or inject an implementation into application code; this contracts package performs no delivery itself.
/// </summary>
public interface ISendSms
{
	/// <summary>
	/// Requests that the active provider send one message to the request's phone number.
	/// </summary>
	/// <param name="request">The destination phone number and message text.</param>
	/// <param name="cancellationToken">The token used to cancel the provider operation.</param>
	/// <returns>A task that completes according to the provider implementation.</returns>
	Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken);
}
