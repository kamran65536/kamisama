namespace Example.Repositories;

public class ExampleDataInitializer(ExampleDbContext context)
{
	public virtual Task MigrateAsync(CancellationToken cancellationToken)
		=> context.Database.MigrateAsync(cancellationToken);

	public virtual Task InitializeAsync(bool initializeTestData, CancellationToken cancelationToken)
	{
		return Task.CompletedTask;
	}
}
