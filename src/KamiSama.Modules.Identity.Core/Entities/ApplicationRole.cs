namespace KamiSama.Modules.Identity.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() { }
        public ApplicationRole(string roleName)
             : base(roleName) { }
    }
}
