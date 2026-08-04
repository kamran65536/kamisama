using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KamiSama.ExternalServices.Exceptions.Exceptions;

namespace KamiSama.ExternalServices.Sms.Features;

[AutoInjectScoped<ISendSms>]
internal class DefaultSendSms(ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IOptions<SmsDefaultsOptions> options) : ISendSms
{
	public Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken)
	{
		var serviceType = options.Value.Sms;
		var smsService = serviceProvider.GetRequiredKeyedService<ISendSms>(serviceType) ?? throw new CannotFindExternalServiceException(nameof(ISendSms), serviceType);

		try
		{
			return smsService.SendSmsAsync(request, cancellationToken);
		}
		catch (Exception exp) when (exp is not HttpExceptionBase)
		{
			loggerFactory.CreateLogger(serviceType + " Sms").LogError(exp, "An error occurred while sending SMS using {ServiceType}", serviceType);

			throw new InvalidResponseForExternalServiceException(serviceType + " Sms", exp.Message);
		}
	}
}
