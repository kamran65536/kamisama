namespace Suma.AdminPanel.Services.Accounts;

public interface IChangePassword
{
	Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
}
