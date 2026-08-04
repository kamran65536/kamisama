namespace KamiSama.Modules.Identity.Features.Users;

internal static class RefreshTokenPurposeFactory
{
	public static string Build(string sessionKey)
		=> $"refresh-token:{sessionKey}";
}
