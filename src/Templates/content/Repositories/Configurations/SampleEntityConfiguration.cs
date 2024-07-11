namespace Example.Repositories.Configurations;

internal class SampleEntityConfiguration : IEntityTypeConfiguration<SampleEntity>
{
	public void Configure(EntityTypeBuilder<SampleEntity> builder)
	{
		builder.Property(x => x.Name).IsRequired();
	}
}
