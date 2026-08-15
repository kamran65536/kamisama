using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using KamiSama.Extensions.Logging;

namespace KamiSama.ExternalServices.Sms.Features;

[AutoInjectScoped<ISendSms>(ServiceKey = "mock")]
internal class MockSendSms(ILogger<MockSendSms> logger) : ISendSms
{
	/// <summary>
	/// Logs method entry and completes without delivering the SMS message.
	/// </summary>
	/// <param name="request">The ignored SMS request.</param>
	/// <param name="cancellationToken">The ignored cancellation token.</param>
	/// <returns>A completed task.</returns>
	public Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		return Task.CompletedTask;
	}
}
