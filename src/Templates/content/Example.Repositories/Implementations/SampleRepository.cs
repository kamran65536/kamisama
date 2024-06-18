namespace Example.Repositories.Implementations;

[AutoInject(Lifetime = ServiceLifetime.Scoped, ServiceType = typeof(ISampleRepository))]
internal class SampleRepository(ExampleDbContext context) : DbRepository<SampleEntity, ExampleDbContext>(context), ISampleRepository 
{
	public Task<SampleEntity?> FindByNameAsync(string name, CancellationToken cancelationToken)
		=> base.FindAsync(x => x.Name.ToLower() == name.ToLower(), cancelationToken);

	public Task<PagedResult<SampleEntity>> ListAsync(SampleEntitySearchModel searchModel, CancellationToken cancelationToken)
	{
		var result = base.Where(x => true);

		if (!string.IsNullOrWhiteSpace(searchModel.Name))
			result = result.Where(x => x.Name.ToLower() == searchModel.Name.ToLower());

		result = (searchModel.OrderBy + "").ToLower() switch
		{
			"name" => result.OrderBy(x => x.Name),
			"id" => result.OrderBy(x => x.Id),
			_ => result.OrderBy(x => x.Id),
		};

		return result.MakePagedAsync(searchModel, cancelationToken);
	}
}
