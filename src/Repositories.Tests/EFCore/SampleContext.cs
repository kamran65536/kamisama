using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Repositories.Tests.EFCore
{
	public class SampleContext : DbContext
	{
		public SampleContext([NotNullAttribute] DbContextOptions options) : base(options)
		{
		}

		protected SampleContext()
		{
		}

		public virtual DbSet<SampleEntity> SampleEntities { get; set; }
	}
}
