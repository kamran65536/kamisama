using KamiSama.Chassis.Commons.Repositories;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules.Contents.Entities;
using KamiSama.Modules.Contents.Features;
using KamiSama.Modules.Contents.Repositories.Abstractions;
using KamiSama.Modules.Contents.Repositories.Database;

namespace KamiSama.Modules.Contents.Repositories.Implementations;

[AutoInjectScoped<IContentFileRepository>]
internal class ContentFileRepository(ContentsDbContext context) :
	GenericRepository<ContentFile, ContentFileSearchModel, ContentsDbContext>(context),
	IContentFileRepository
{
	protected override IQueryable<ContentFile> ApplySearchModel(IQueryable<ContentFile> query, ContentFileSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.FileName))
			query = query.Where(x => x.FileName.ToLower() == searchModel.FileName.ToLower());
		if (!string.IsNullOrWhiteSpace(searchModel.ContentType))
			query = query.Where(x => x.ContentType.ToLower() == searchModel.ContentType.ToLower());
		if (searchModel.UserId != null)
			query = query.Where(x => x.OwnerUserId == searchModel.UserId);

		return (searchModel.OrderBy ?? "").ToLower() switch
		{
			"filename" => query.OrderBy(x => x.FileName),
			"contenttype" => query.OrderBy(x => x.ContentType),
			_ => query.OrderBy(x => x.CreatedAt)
		};
	}

	public Task<ContentFile?> FindByUserIdAndNameAsync(Guid userId, string name, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.OwnerUserId == userId && x.FileName.ToLower() == name.ToLower(), cancellationToken);

	public Task<bool> ExistsByUserIdAndNameAsync(Guid userId, string name, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.OwnerUserId == userId && x.FileName.ToLower() == name.ToLower(), cancellationToken);

	public Task<ContentFile?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);

	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);
}
