using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using KamiSama.Extensions.Logging;

namespace KamiSama.ExternalServices.Sms.Features;

[AutoInjectScoped<ISendSms>(ServiceKey = "mock")]
internal class MockSendSms(ILogger<MockSendSms> logger) : ISendSms
{
	public Task SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		return Task.CompletedTask;
	}
}
