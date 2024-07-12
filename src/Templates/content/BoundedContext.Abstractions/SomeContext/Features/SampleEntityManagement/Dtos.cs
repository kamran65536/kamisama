namespace Example.SomeContext.Features.SampleEntityManagement;

public record AddSampleEntityRequest([Required] string Name);
public record UpdateSampleEntityRequest([Required] string Name);
public record SampleEntityDto(Guid Id, string Name);

public record SampleEntitySearchModel(int Page, int PageSize, string? Name) : SearchModel(Page, PageSize)
{
	public static new SampleEntitySearchModel All { get; } = new(0, 0, null);
}