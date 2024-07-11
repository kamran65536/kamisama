namespace Project.Abstractions.Features.SampleEntityManagement;

public interface IAddSampleEntity : IAddFeature<AddSampleEntityRequest>
{
}
public interface IUpdateSampleEntity : IUpdateFeature<UpdateSampleEntityRequest>
{
}
public interface IDeleteSampleEntity : IDeleteFeature<Guid>
{
}
public interface IListSampleEntity : IListFeature<SampleEntityDto, SampleEntitySearchModel>
{
}
public interface IFindSampleEntityByName : IFindByNameFeature<SampleEntityDto>
{
}