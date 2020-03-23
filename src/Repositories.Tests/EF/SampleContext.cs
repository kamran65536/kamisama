using System.Data.Entity;

namespace KamiSama.Repositories.Tests.EF
{
	public class SampleContext : DbContext
	{
		public virtual DbSet<SampleEntity> SampleEntities { get; set; }
	}
}
