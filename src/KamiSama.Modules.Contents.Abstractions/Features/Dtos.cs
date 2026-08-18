using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Contents.Features;

/// <summary>
/// Specifies paging, owner and file filters, and ordering input for content-file queries.
/// </summary>
/// <param name="Page">The one-based page number; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="PageSize">The requested page size; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="UserId">An optional owner identifier matched exactly against stored content files.</param>
/// <param name="FileName">An optional file name matched case-insensitively for exact equality.</param>
/// <param name="ContentType">An optional content type matched case-insensitively for exact equality.</param>
/// <param name="OrderBy">An optional ordering token. Recognized values are <c>filename</c> and <c>contenttype</c>; any other value orders by creation date.</param>
public record ContentFileSearchModel(int Page, int PageSize, Guid? UserId, string? FileName, string? ContentType, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets or sets an unpaged search model without owner or file filtering.
	/// </summary>
	/// <value>A reusable model whose paging and optional filter values are all defaults.</value>
	public static new ContentFileSearchModel All { get; set; } = new(default, default, default, default, default, default);
}

/// <summary>
/// Represents a content file's metadata, without its binary payload, for list views.
/// </summary>
/// <param name="Id">The content file identifier.</param>
/// <param name="OwnerUserId">The owning user identifier, or <see langword="null"/> for files with no owner.</param>
/// <param name="FileName">The stored file name.</param>
/// <param name="ContentType">The stored MIME content type.</param>
/// <param name="CreatedAt">The UTC timestamp the file was uploaded at.</param>
public record ContentFileListItemDto(Guid Id, Guid? OwnerUserId, string FileName, string ContentType, DateTime CreatedAt);

/// <summary>
/// Represents a content file's metadata and binary payload.
/// </summary>
/// <param name="Id">The content file identifier.</param>
/// <param name="OwnerUserId">The owning user identifier, or <see langword="null"/> for files with no owner.</param>
/// <param name="FileName">The stored file name.</param>
/// <param name="ContentType">The stored MIME content type.</param>
/// <param name="CreatedAt">The UTC timestamp the file was uploaded at.</param>
/// <param name="Data">The raw file bytes.</param>
public record ContentFileDto(Guid Id, Guid? OwnerUserId, string FileName, string ContentType, DateTime CreatedAt, byte[] Data);

/// <summary>
/// Supplies the owner, name, content type, and binary payload for a new content file.
/// </summary>
/// <param name="OwnerUserId">The owning user identifier, or <see langword="null"/> to create a file with no owner.</param>
/// <param name="FileName">The file name to store, limited to 100 characters by the Core EF model.</param>
/// <param name="ContentType">The MIME content type to store, limited to 50 characters by the Core EF model.</param>
/// <param name="Data">The raw file bytes, limited to <see cref="Consts.MaxFileSize"/> bytes.</param>
public record AddContentFileRequest(Guid? OwnerUserId, string FileName, string ContentType, [property: MaxLength(Consts.MaxFileSize)] byte[] Data);
