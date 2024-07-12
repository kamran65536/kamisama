using Example.BoundedContext.Features.SampleEntityManagement;

namespace Example.BoundedContext.Repositories.Abstractions;

public interface ISampleEntityRepository
	: IGenericRepository<SampleEntity, SampleEntitySearchModel>, IFindByNameRepository<SampleEntity>
{
}
