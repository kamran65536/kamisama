namespace KamiSama.ExternalServices.Email.Features;

/// <summary>
/// Contains the provider-neutral data required to send one email message.
/// Use it with <see cref="ISendEmail.SendEmailAsync"/> regardless of the underlying email transport.
/// </summary>
/// <param name="RecipientAddress">The destination email address.</param>
/// <param name="Subject">The email subject line.</param>
/// <param name="Body">The plain-text or HTML message body.</param>
/// <param name="IsHtml">Whether <paramref name="Body"/> contains HTML content.</param>
public record SendEmailRequest(string RecipientAddress, string Subject, string Body, bool IsHtml);
