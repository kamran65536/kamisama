using System.Data.Entity;

namespace TestConsole
{
	public class KamranDbContext : DbContext
	{
		public DbSet<Kamran> Kamrans { get; set; }

		public KamranDbContext()
			: base("name=KamranDbContext")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("FALLAHTEST");
		}
	}
}
