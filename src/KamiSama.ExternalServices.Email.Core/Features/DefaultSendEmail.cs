using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KamiSama.ExternalServices.Exceptions.Exceptions;

namespace KamiSama.ExternalServices.Email.Features;

[AutoInjectScoped<ISendEmail>]
internal class DefaultSendEmail(ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IOptions<EmailDefaultsOptions> options) : ISendEmail
{
	public Task SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken)
	{
		var serviceType = options.Value.Email;
		var emailService = serviceProvider.GetKeyedService<ISendEmail>(serviceType) ?? throw new CannotFindExternalServiceException(nameof(ISendEmail), serviceType);

		try
		{
			return emailService.SendEmailAsync(request, cancellationToken);
		}
		catch (Exception exp) when (exp is not HttpExceptionBase)
		{
			loggerFactory.CreateLogger(serviceType).LogError(exp, "Invalid response for email service: {}", serviceType);

			throw new InvalidResponseForExternalServiceException(serviceType + " Email", exp.Message);
		}
	}
}