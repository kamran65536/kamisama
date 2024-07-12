namespace Example.SomeContext.Features.SampleEntityManagement;

public interface IAddSampleEntity : IAddFeature<AddSampleEntityRequest>
{
}
public interface IUpdateSampleEntity : IUpdateFeature<UpdateSampleEntityRequest, Guid>
{
}
public interface IDeleteSampleEntity : IDeleteFeature<Guid>
{
}
public interface IListSampleEntities : IListFeature<SampleEntityDto, SampleEntitySearchModel>
{
}
public interface IFindByNameSampleEntityByName : IFindByNameFeature<SampleEntityDto>
{
}
public interface IFindByIdSampleEntityByName : IFindByIdFeature<SampleEntityDto, Guid>
{
}