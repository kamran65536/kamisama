namespace KamiSama.ExternalServices.Sms.Features;

/// <summary>
/// Defines a contract for sending SMS messages.
/// </summary>
public interface ISendSms
{
	/// <summary>
	/// Sends an SMS message to the specified phone number.
	/// </summary>
	Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken);
}