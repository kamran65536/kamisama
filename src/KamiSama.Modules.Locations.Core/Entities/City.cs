using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Locations.Entities;

public class City
{
	public Guid Id { get; set; }

	public required virtual Province Province { get; set; }

	[MaxLength(100)]
	public required string Name { get; set; }
}
