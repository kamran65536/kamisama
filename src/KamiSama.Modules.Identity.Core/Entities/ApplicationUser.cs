namespace KamiSama.Modules.Identity.Entities;

/// <summary>
/// Represents the module's ASP.NET Core Identity user with a <see cref="Guid"/> key and application-session navigation.
/// Identity stores inherited profile, credential, confirmation, and lockout state.
/// </summary>
public class ApplicationUser : IdentityUser<Guid>
{
    /// <summary>Initializes an empty user for Identity and Entity Framework Core materialization.</summary>
    public ApplicationUser() { }
    /// <summary>Initializes a user with the supplied user name.</summary>
    /// <param name="userName">The initial user name.</param>
    public ApplicationUser(string userName)
         : base(userName) { }

	/// <summary>Gets or sets the sessions associated with this user.</summary>
	public virtual ICollection<ApplicationSession> Sessions { get; set; } = [];
}
