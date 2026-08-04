using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Locations.Entities;

public class Province
{
	public Guid Id { get; set; }

	[MaxLength(100)]
	public required string Name { get; set; }

	public virtual ICollection<City> Cities { get; set; } = [];
}
