namespace Example.BoundedContext.Features.SampleEntityManagement;

internal class Mappings : Profile
{
	public Mappings()
	{
		CreateMap<AddSampleEntity, SampleEntity>();
		CreateMap<UpdateSampleEntity, SampleEntity>().JustPatchMembers();
		CreateMap<SampleEntity, SampleEntityDto>();
	}
}
