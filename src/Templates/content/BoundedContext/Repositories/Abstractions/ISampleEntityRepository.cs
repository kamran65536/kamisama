using Example.BoundedContext.Features.SampleEntityManagement;

namespace Example.BoundedContext.Repositories.Abstractions;
public interface ISampleEntityRepository :
	IGenericRepository<SampleEntity, SampleEntitySearchModel>,
	IFindByIdRepository<SampleEntity, Guid>,
	IFindByNameRepository<SampleEntity>
{
}
