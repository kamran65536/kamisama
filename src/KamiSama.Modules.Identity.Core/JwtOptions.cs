namespace KamiSama.Modules.Identity;

internal class JwtOptions
{
	public required string Key { get; set; } = "";
	public required string Issuer { get; set; } = "";
	public required string Audience { get; set; } = "";
	public required TimeSpan AccessTokenExpiration { get; set; } = TimeSpan.FromMinutes(1);
}
