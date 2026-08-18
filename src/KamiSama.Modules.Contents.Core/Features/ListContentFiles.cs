using KamiSama.Modules.Contents.Repositories.Abstractions;

namespace KamiSama.Modules.Contents.Features;

/// <summary>
/// Lists a page of content files, without their binary payload, using owner and file filters.
/// </summary>
[AutoInjectScoped<IListContentFiles>]
internal class ListContentFiles(IContentFileRepository repository) :
	GenericListFeature<ContentFile, ContentFileListItemDto, ContentFileSearchModel, IContentFileRepository>(repository),
	IListContentFiles
{
	protected override Task<ContentFileListItemDto> ConvertToDto(ContentFile entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToListItemDto());
}
