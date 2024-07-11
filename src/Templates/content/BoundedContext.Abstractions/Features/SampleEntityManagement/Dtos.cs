namespace Example.Abstractions.Features.SampleEntityManagement;

public record AddSampleEntityRequest([Required] string Name);
public record UpdateSampleEntityRequest([Required] string Name);
public record SampleEntityDto(Guid Id, string Name);

public record SampleEntitySearchModel(int Page, int PageSize, string? Name) : SearchModel(Page, PageSize)
{
	public static new SampleEntitySearchModel All = new(0, 0, null);
}