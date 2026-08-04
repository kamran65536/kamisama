using KamiSama.Chassis.HttpExceptions;
using KamiSama.Extensions.DependencyInjection;
using Kavenegar;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KamiSama.Extensions.Logging;
using KamiSama.ExternalServices.Sms.Features;

namespace KamiSama.ExternalServices.Sms.Kavenegar;

[AutoInjectScoped<ISendSms>(ServiceKey = "kavenegar")]
internal class KavenegarSendSms(IOptions<KavenegarSmsOptions> options, ILogger<KavenegarSendSms> logger) : ISendSms
{
	public Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		if (options.Value.IsValid())
			throw new InvalidOperationHttpException("configuration for kavenegar sms is not ok.");
		var api = new KavenegarApi(options.Value.ApiKey);

		api.Send(options.Value.SenderPhoneNumber, request.PhoneNumber, request.Message);

		return Task.CompletedTask;
	}
}
