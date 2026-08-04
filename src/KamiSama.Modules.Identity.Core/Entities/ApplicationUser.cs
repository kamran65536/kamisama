namespace KamiSama.Modules.Identity.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser() { }
    public ApplicationUser(string userName)
         : base(userName) { }

	public virtual ICollection<ApplicationSession> Sessions { get; set; } = [];
}
