namespace KamiSama.Modules.Identity.DataTypes;


/// <summary>
/// Defines the canonical role names recognized by applications that adopt the Identity module's built-in role vocabulary.
/// These constants do not create roles or authorize a feature call; applications must seed roles and enforce authorization separately.
/// </summary>
public static class KnownRoles {
	/// <summary>Identifies the unrestricted administrative role.</summary>
	public const string SuperAdmin = "SuperAdmin";
	/// <summary>Identifies an operational staff role with application-defined permissions.</summary>
	public const string Operator = "Operator";
	/// <summary>Identifies the standard application-user role.</summary>
	public const string User = "User";
}
