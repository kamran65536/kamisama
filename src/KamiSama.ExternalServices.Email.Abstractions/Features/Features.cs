namespace KamiSama.ExternalServices.Email.Features;

public interface ISendEmail
{
	Task SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken);
}