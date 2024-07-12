using Example.BoundedContext.Features.SampleEntityManagement;

namespace Example.Repositories.Abstractions;

public interface ISampleEntityRepository
	: IGenericRepository<SampleEntity, SampleEntitySearchModel>, IFindByNameRepository<SampleEntity>
{
}
