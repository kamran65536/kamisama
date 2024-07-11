namespace KamiSama.Repositories.Abstractions;

public interface ISampleRepository 
	: IGenericRepository<SampleEntity, SampleEntitySearchModel>, IFindByNameRepository<SampleEntity>
{
}
