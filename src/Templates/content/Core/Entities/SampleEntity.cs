using System.ComponentModel.DataAnnotations;

namespace ExampleCore.Entities;

public class SampleEntity
{
	public Guid Id { get; set; }

	[MaxLength(200)]
	public required string Name { get; set; }

	public required DateTime CreatedAt { get; set; }

	public required DateTime UpdatedAt { get; set; }
}
