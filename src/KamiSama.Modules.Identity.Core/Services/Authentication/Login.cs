using KamiSama.Modules.Identity.Services.Users;

namespace KamiSama.Modules.Identity.Services.Authentication;

[AutoInjectScoped<ILogin>]
internal class Login(
	IAuthenticateUser authenticateUser,
	ITokenService tokenService) : ILogin
{
	public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
			throw new BadRequestException("Login and password are required.");

		var user = await authenticateUser.AuthenticateAsync(
			null,
			request.Login,
			request.Password,
			request.TwoFactorCode,
			cancellationToken);
		var tokens = await tokenService.GenerateTokenPairAsync(user.Id, cancellationToken);

		return new LoginResponse(user, tokens);
	}
}
