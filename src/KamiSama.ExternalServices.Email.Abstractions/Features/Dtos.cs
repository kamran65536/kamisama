namespace KamiSama.ExternalServices.Email.Features;

public record SendEmailRequest(string RecipientAddress, string Subject, string Body, bool IsHtml);
