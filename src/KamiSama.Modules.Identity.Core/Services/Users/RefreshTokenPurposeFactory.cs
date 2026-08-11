namespace KamiSama.Modules.Identity.Services.Users;

internal static class RefreshTokenPurposeFactory
{
	public static string Build(string sessionKey)
		=> $"refresh-token:{sessionKey}";
}
