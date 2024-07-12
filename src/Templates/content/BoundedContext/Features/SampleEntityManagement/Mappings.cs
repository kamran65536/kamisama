namespace Example.BoundedContext.Features.SampleEntityManagement;

internal class Mappings : Profile
{
	public Mappings()
	{
		CreateMap<AddSampleEntity, SampleEntity>();
		CreatePatchedMap<UpdateSampleEntity, SampleEntity>();
		CreateMap<SampleEntity, SampleEntityDto>();
	}
}
