using System.ComponentModel.DataAnnotations;

namespace ExampleNamespace.Entities;

public class SampleEntity
{
	public Guid Id { get; set; }

	[MaxLength(200)]
	public required string Name { get; set; }

	public required DateTime CreatedAt { get; set; }

	public required DateTime UpdatedAt { get; set; }
}
