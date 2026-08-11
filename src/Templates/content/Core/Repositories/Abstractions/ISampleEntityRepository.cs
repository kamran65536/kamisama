namespace ExampleNamespace.Repositories.Abstractions;

internal interface ISampleEntityRepository :
	IGenericRepository<SampleEntity, SearchModel>,
	ILookupByIdRepository<SampleEntity, Guid>,
	ILookupByNameRepository<SampleEntity>
{
}
