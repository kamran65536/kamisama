using KamiSama.Modules.Contents.Repositories.Abstractions;

namespace KamiSama.Modules.Contents.Features;

/// <summary>
/// Creates a new content file from the uploaded name, content type, and binary payload.
/// </summary>
[AutoInjectScoped<IAddContentFile>]
internal class AddContentFile(IContentFileRepository repository) :
	GenericAddFeature<AddContentFileRequest, IContentFileRepository, ContentFile, ContentFileDto>(repository),
	IAddContentFile
{
	protected override Task<ContentFile> ConvertToEntity(AddContentFileRequest request, CancellationToken cancellationToken)
		=> Task.FromResult(new ContentFile
		{
			ContentType = request.ContentType,
			CreatedAt = DateTime.UtcNow,
			Data = request.Data,
			FileName = request.FileName,
			OwnerUserId = request.OwnerUserId,
		});

	protected override Task<ContentFileDto> ConvertToDto(ContentFile entity, CancellationToken cancellationToken)
		=> Task.FromResult(entity.ToDto());
}
