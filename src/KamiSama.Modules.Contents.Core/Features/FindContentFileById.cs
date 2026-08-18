using KamiSama.Modules.Contents.Repositories.Abstractions;

namespace KamiSama.Modules.Contents.Features;

/// <summary>
/// Finds a content file by its <see cref="Guid"/> identifier and returns its complete DTO, including binary payload.
/// </summary>
[AutoInjectScoped<IFindContentFileById>]
internal class FindContentFileById(IContentFileRepository repository) :
	GenericFindByIdFeature<ContentFile, ContentFileDto, IContentFileRepository, Guid>(repository),
	IFindContentFileById
{
	protected override Task<ContentFileDto> ConvertToDto(ContentFile entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
