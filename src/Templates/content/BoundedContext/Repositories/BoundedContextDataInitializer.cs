namespace Example.BoundedContext.Repositories.Database;

[AutoInjectScoped(typeof(IDatabaseInitializer<BoundedContextDbContext>))]
internal class BoundedContextDataInitializer(BoundedContextDbContext context) : DatabaseInitializerBase<BoundedContextDbContext>(context)
{
    protected override Task InitializeDataAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
	}
    protected override Task InitializeTestDataAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
	}
}
