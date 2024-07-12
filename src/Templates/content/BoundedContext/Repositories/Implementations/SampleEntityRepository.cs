using Example.BoundedContext.Features.SampleEntityManagement;

namespace Example.BoundedContext.Repositories.Implementations;

[AutoInjectScoped(typeof(ISampleEntityRepository))]
internal class SampleEntityRepository(BoundedContextDbContext context)
	: GenericRepository<SampleEntity, SampleEntitySearchModel, BoundedContextDbContext>(context), ISampleEntityRepository
{
	protected override IQueryable<SampleEntity> ApplySearchModel(IQueryable<SampleEntity> query, SampleEntitySearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
			query = query.Where(x => x.Name.ToLower() == searchModel.Name.ToLower());

		return (searchModel.OrderBy ?? "").ToLower() switch
		{
			"id" => query.OrderBy(x => x.Id),
			"name" => query.OrderBy(x => x.Name),
			_ => query.OrderBy(x => x.Id),
		};
	}
}
