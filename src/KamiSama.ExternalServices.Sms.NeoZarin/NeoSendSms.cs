using KamiSama.Chassis.HttpExceptions;
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KamiSama.Extensions.Logging;
using KamiSama.Extensions.RestSharp;
using KamiSama.ExternalServices.Sms.Features;

namespace KamiSama.ExternalServices.Sms.NeoZarin;

[AutoInjectScoped<ISendSms>(ServiceKey = "neo-zarin")]
internal class NeoSendSms(IRestBuilder restBuilder, IOptions<NeoZarinSmsOptions> options, ILogger<NeoSendSms> logger) : ISendSms
{
	/// <summary>
	/// Attempts to post an SMS request to the configured NeoZarin endpoint.
	/// </summary>
	/// <param name="request">The destination phone number and message to send.</param>
	/// <param name="cancellationToken">The token forwarded to the RestSharp request.</param>
	/// <returns>A task that represents the HTTP request.</returns>
	/// <remarks>The current validation condition is inverted and rejects settings when <see cref="NeoZarinSmsOptions.IsValidForSms"/> returns <see langword="true"/>.</remarks>
	public async Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		if (options.Value.IsValidForSms())
			throw new InvalidOperationHttpException("configuration for neo-zarin sms is not ok.");

		await restBuilder
			.ForServiceUrl(options.Value.BaseUrl!, options.Value.SmsApiPath!)
			.AddParameter("username", options.Value.Username)
			.AddParameter("password", options.Value.Password)
			.AddParameter("api", options.Value.SmsApi)
			.AddParameter("from", options.Value.SmsSenderPhoneNumber)
			.AddParameter("to[0]", request.PhoneNumber)
			.AddParameter("text[0]", request.Message)
			.PostAsyncWithoutResponse(cancellationToken);
	}
}
