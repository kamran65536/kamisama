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
	/// <summary>
	/// Attempts to send an SMS through the synchronous Kavenegar SDK call.
	/// </summary>
	/// <param name="request">The destination phone number and message to send.</param>
	/// <param name="cancellationToken">The token accepted by the contract but not observed by this implementation.</param>
	/// <returns>A completed task after the synchronous SDK call returns.</returns>
	/// <remarks>The current validation condition is inverted and rejects settings when <see cref="KavenegarSmsOptions.IsValid"/> returns <see langword="true"/>.</remarks>
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
