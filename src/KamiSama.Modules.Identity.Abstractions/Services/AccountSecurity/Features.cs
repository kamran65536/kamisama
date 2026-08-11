namespace KamiSama.Modules.Identity.Services.AccountSecurity;

public interface IListActiveSessions
{
	Task<IReadOnlyList<ActiveSessionDto>> ListAsync(Guid userId, CancellationToken cancellationToken);
}

public interface ITerminateAllOtherSessions
{
	Task TerminateAllOtherAsync(Guid userId, CancellationToken cancellationToken);
}

public interface ITerminateSession
{
	Task TerminateAsync(Guid userId, string sessionId, CancellationToken cancellationToken);
}

public interface IGetAuthenticatorSecret
{
	Task<string> GetAsync(Guid userId, CancellationToken cancellationToken);
}

public interface IChangePassword
{
	Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
}

public interface IIsTwoFactorAuthenticationEnabled
{
	Task<bool> IsEnabledAsync(Guid userId, CancellationToken cancellationToken);
}

public interface ISetTwoFactorAuthenticationEnabled
{
	Task SetAsync(Guid userId, bool isEnabled, CancellationToken cancellationToken);
}

public interface IValidateAuthenticatorCode
{
	Task ValidateAsync(ValidateAuthenticatorCodeRequest request, CancellationToken cancellationToken);
}
