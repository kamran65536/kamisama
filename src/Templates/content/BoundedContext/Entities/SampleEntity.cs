namespace Example.BoundedContext.Entities;

public class SampleEntity
{
	public Guid Id { get; set; }
	[MaxLength(100)]
	public required string Name { get; set; }
}
