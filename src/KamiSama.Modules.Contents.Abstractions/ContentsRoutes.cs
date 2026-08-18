namespace KamiSama.Modules.Contents;

/// <summary>
/// Defines the relative route segments used by the Contents module's management and user-facing APIs.
/// </summary>
/// <remarks>Both <see cref="ManagementApiPath"/> and <see cref="UserApiPath"/> currently share the same base path.</remarks>
public static class ContentsRoutes
{
	/// <summary>The base path for management endpoints.</summary>
	public const string ManagementApiPath = "/api/contents";
	/// <summary>The base path for user-facing endpoints.</summary>
	public const string UserApiPath = "/api/contents";
	/// <summary>The relative segment for listing content files.</summary>
	public const string List = "";
	/// <summary>The relative segment for finding a content file by identifier.</summary>
	public const string FindById = "";
	/// <summary>The relative segment for uploading a new content file.</summary>
	public const string Upload = "upload";
	/// <summary>The relative segment for deleting a content file.</summary>
	public const string Delete = "";
}
