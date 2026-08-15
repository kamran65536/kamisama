namespace KamiSama.Modules.Identity.Entities
{
    /// <summary>Represents the module's ASP.NET Core Identity role with a <see cref="Guid"/> key.</summary>
    public class ApplicationRole : IdentityRole<Guid>
    {
        /// <summary>Initializes an empty role for Identity and Entity Framework Core materialization.</summary>
        public ApplicationRole() { }
        /// <summary>Initializes a role with the supplied name.</summary>
        /// <param name="roleName">The initial role name.</param>
        public ApplicationRole(string roleName)
             : base(roleName) { }
    }
}
