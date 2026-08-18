using KamiSama.Modules.Contents.Entities;
using KamiSama.Modules.Contents.Features;
using Riok.Mapperly.Abstractions;

namespace KamiSama.Modules.Contents;

/// <summary>
/// Maps content-file entities to their provider-neutral DTOs.
/// </summary>
[Mapper]
internal static partial class DtoMappings
{
	/// <summary>Maps a content file to the compact list representation without its binary payload.</summary>
	/// <param name="file">The content file entity to map.</param>
	/// <returns>The mapped list item, omitting <see cref="ContentFile.Data"/>.</returns>
	[MapperIgnoreSource(nameof(ContentFile.Data))]
	public static partial ContentFileListItemDto ToListItemDto(this ContentFile file);
	/// <summary>Maps a content file to its complete public representation, including its binary payload.</summary>
	/// <param name="file">The content file entity to map.</param>
	/// <returns>The mapped content file.</returns>
	public static partial ContentFileDto ToDto(this ContentFile file);
}
