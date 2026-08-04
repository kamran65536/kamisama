using KamiSama.ExternalServices.Email.Features;
namespace KamiSama.Modules.Identity.Features.Email;

[AutoInjectScoped<IEmailSender<ApplicationUser>>]
internal class EmailSender(ISendEmail sendEmail) : IEmailSender<ApplicationUser>
{
	public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
	{
		var request = new SendEmailRequest(email, "Confirm your email address", confirmationLink, true);
		
		await sendEmail.SendEmailAsync(request, CancellationToken.None);
	}

	public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
	{
		var request = new SendEmailRequest(email, "Password Reset Code", resetCode, true);
		
		await sendEmail.SendEmailAsync(request, CancellationToken.None);
	}

	public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
	{
		var request = new SendEmailRequest(email, "Password Reset Link", resetLink, true);

		await sendEmail.SendEmailAsync(request, CancellationToken.None);
	}
}
