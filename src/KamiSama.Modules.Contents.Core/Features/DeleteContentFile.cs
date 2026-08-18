using KamiSama.Modules.Contents.Repositories.Abstractions;

namespace KamiSama.Modules.Contents.Features;

/// <summary>
/// Deletes an existing content file identified by <see cref="Guid"/>.
/// </summary>
[AutoInjectScoped<IDeleteContentFile>]
internal class DeleteContentFile(IContentFileRepository repository) :
	GenericDeleteFeature<ContentFile, IContentFileRepository, Guid>(repository),
	IDeleteContentFile
{
}
