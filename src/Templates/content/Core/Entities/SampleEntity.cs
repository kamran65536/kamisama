using System.ComponentModel.DataAnnotations;

namespace Example.Core.Entities;

public class SampleEntity
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
}
