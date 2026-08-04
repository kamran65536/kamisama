using Microsoft.EntityFrameworkCore;
using KamiSama.Modules.Locations.Features;
using KamiSama.Modules.Locations.Repositories.Abstractions;
using KamiSama.Modules.Locations.Repositories.Database;

namespace KamiSama.Modules.Locations.Repositories.Implementations;

[AutoInjectScoped<IProvinceRepository>]
internal class ProvinceRepository(LocationsDbContext context) :
	GenericRepository<Province, ProvinceSearchModel, LocationsDbContext>(context),
	IProvinceRepository
{
	protected override IQueryable<Province> ApplySearchModel(IQueryable<Province> query, ProvinceSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
		{
			var name = searchModel.Name.ToLower();
			query = query.Where(x => x.Name.ToLower().Contains(name));
		}

		return (searchModel.OrderBy ?? string.Empty).ToLower() switch
		{
			_ => query.OrderBy(x => x.Name),
		};
	}

	public Task<Province?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);
}
