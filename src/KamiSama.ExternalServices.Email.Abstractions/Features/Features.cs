namespace KamiSama.ExternalServices.Email.Features;

/// <summary>
/// Defines the provider-neutral operation for sending an email message.
/// Implement this contract in a transport package or inject it into application code that sends email.
/// </summary>
public interface ISendEmail
{
	/// <summary>
	/// Sends the supplied email message through the configured provider.
	/// </summary>
	/// <param name="request">The recipient, subject, body, and content format to send.</param>
	/// <param name="cancellationToken">The token used to cancel the send operation.</param>
	/// <returns>A task representing the send operation.</returns>
	Task SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken);
}
