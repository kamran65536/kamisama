namespace Example.BoundedContext.Features.SampleEntityManagement;

internal class MyMappings : Profile
{
	public MyMappings()
	{
		CreateMap<AddSampleEntityRequest, SampleEntity>();
		CreateMap<UpdateSampleEntityRequest, SampleEntity>().JustPatchMembers();
		CreateMap<SampleEntity, SampleEntityDto>();
	}
}
