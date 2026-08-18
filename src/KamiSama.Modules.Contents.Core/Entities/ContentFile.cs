using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.Contents.Entities;

/// <summary>
/// Represents a persisted content file and its binary payload.
/// </summary>
public class ContentFile
{
	/// <summary>Gets or sets the content file identifier.</summary>
	/// <value>The EF Core primary key.</value>
	public Guid Id { get; set; }

	/// <summary>Gets or sets the owning user identifier.</summary>
	/// <value><see langword="null"/> for content files with no owner.</value>
	public required Guid? OwnerUserId { get; set; }

	/// <summary>Gets or sets the stored file name.</summary>
	/// <value>A value with a maximum persisted length of 100 characters.</value>
	[MaxLength(100)]
	public required string FileName { get; set; }

	/// <summary>Gets or sets the stored MIME content type.</summary>
	/// <value>A value with a maximum persisted length of 50 characters.</value>
	[MaxLength(50)]
	public required string ContentType { get; set; }

	/// <summary>Gets or sets the raw file bytes.</summary>
	/// <value>A value with a maximum persisted length of <see cref="Consts.MaxFileSize"/> bytes.</value>
	[MaxLength(Consts.MaxFileSize)]
	public required byte[] Data { get; set; }

	/// <summary>Gets or sets the UTC timestamp the file was uploaded at.</summary>
	public required DateTime CreatedAt { get; set; }
}
