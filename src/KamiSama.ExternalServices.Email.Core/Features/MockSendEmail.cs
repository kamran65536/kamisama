using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using KamiSama.Extensions.Logging;

namespace KamiSama.ExternalServices.Email.Features;

[AutoInjectScoped<ISendEmail>(ServiceKey = "mock")]
internal class MockSendEmail(ILogger<MockSendEmail> logger) : ISendEmail
{
	public Task SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		return Task.CompletedTask;
	}
}
