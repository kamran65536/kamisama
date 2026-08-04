using KamiSama.Chassis.HttpExceptions;
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KamiSama.Extensions.Logging;
using KamiSama.ExternalServices.Email.Features;
using System.Net;
using System.Net.Mail;

namespace KamiSama.ExternalServices.Email.Smtp;

[AutoInjectScoped<ISendEmail>(ServiceKey = "smtp")]
internal class SmtpSendEmail(IOptions<SmtpOptions> options, ILogger<SmtpSendEmail> logger) : ISendEmail
{
	public async Task SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		if (options.Value.IsValid())
			throw new InvalidOperationHttpException("configuration for smtp is not ok.");
		using var client = new SmtpClient(options.Value.Host, options.Value.Port);
		client.Credentials = new NetworkCredential(options.Value.Username, options.Value.Password);
		client.EnableSsl = options.Value.UseSsl;

		var fromAddress = new MailAddress(options.Value.SenderAddress!, options.Value.SenderAddressName);
		var toAddress = new MailAddress(request.RecipientAddress);

		var message = new MailMessage(fromAddress, toAddress)
		{
			Subject = request.Subject,
			Body = request.Body,
			IsBodyHtml = request.IsHtml,
		};

		await client.SendMailAsync(message, cancellationToken);
	}
}
