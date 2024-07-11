namespace KamiSama.Templates.content.BoundedContext.Repositories.Database;

[AutoInjectScoped(typeof(IDatabaseInitializer<BoundedContextDbContext>))]
internal class BoundedContextDataInitializer : DatabaseInitializerBase<BoundedContextDbContext>
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
