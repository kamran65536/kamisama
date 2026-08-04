using ExampleCore.Repositories.Abstractions;

namespace ExampleCore.Repositories.Implementations;

[ExcludeFromCodeCoverage]
[AutoInjectScoped<ISampleEntityRepository>]
internal class SampleEntityRepository(ExampleCoreDbContext context) :
	GenericRepository<SampleEntity, SearchModel, ExampleCoreDbContext>(context),
	ISampleEntityRepository
{
	public Task<SampleEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);

	public Task<SampleEntity?> FindByNameAsync(string name, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);

	public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);

	protected override IQueryable<SampleEntity> ApplySearchModel(IQueryable<SampleEntity> query, SearchModel searchModel)
		=> query.OrderBy(x => x.Name);
}
