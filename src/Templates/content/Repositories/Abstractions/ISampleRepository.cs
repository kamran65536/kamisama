namespace Project.Repositories.Abstractions;

public interface ISampleRepository
{
	Task<SampleEntity?> FindByNameAsync(string name, CancellationToken cancelationToken);
	Task<PagedResult<SampleEntity>> ListAsync(SampleEntitySearchModel searchModel, CancellationToken cancelationToken);
	Task AddAsync(SampleEntity entity, CancellationToken cancelationToken);
}
