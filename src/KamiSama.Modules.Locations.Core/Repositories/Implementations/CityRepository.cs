using KamiSama.Extensions.Paging;
using KamiSama.Modules.Locations.Features;
using KamiSama.Modules.Locations.Repositories.Abstractions;
using KamiSama.Repositories.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Locations.Repositories.Implementations;

[AutoInjectScoped<ICityRepository>]
internal class CityRepository(LocationsDbContext context) :
	GenericRepository<City, CitySearchModel, LocationsDbContext>(context),
	ICityRepository
{
	protected override IQueryable<City> ApplySearchModel(IQueryable<City> query, CitySearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Name))
		{
			var name = searchModel.Name.ToLower();
			query = query.Where(x => x.Name.ToLower().Contains(name));
		}

		if (searchModel.ProvinceId is not null)
			query = query.Where(x => x.Province.Id == searchModel.ProvinceId);

		if (!string.IsNullOrWhiteSpace(searchModel.ProvinceName))
		{
			var provinceName = searchModel.ProvinceName.ToLower();
			query = query.Where(x => x.Province.Name.ToLower().Contains(provinceName));
		}

		return (searchModel.OrderBy ?? string.Empty).ToLower() switch
		{
			"province" => query.OrderBy(x => x.Province.Name).ThenBy(x => x.Name),
			_ => query.OrderBy(x => x.Name),
		};
	}

	public Task<City?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);
}
