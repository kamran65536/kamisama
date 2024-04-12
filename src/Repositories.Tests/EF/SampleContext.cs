using System.Data.Common;
using System.Data.Entity;

namespace KamiSama.Repositories.Tests.EF;

public class SampleContext : DbContext
{
	public SampleContext(DbConnection existingConnection, bool dbContextOwnsObjectContext) 
		: base(existingConnection, dbContextOwnsObjectContext)
	{
		SampleEntities = Set<SampleEntity>();
	}

	public virtual DbSet<SampleEntity> SampleEntities { get; set; }
}
