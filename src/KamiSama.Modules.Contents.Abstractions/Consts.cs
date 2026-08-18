namespace KamiSama.Modules.Contents;

/// <summary>
/// Holds shared constants for the Contents module.
/// </summary>
/// <remarks>Exposed to <c>KamiSama.Modules.Contents.Core</c> through <see cref="System.Runtime.CompilerServices.InternalsVisibleToAttribute"/>.</remarks>
internal class Consts
{
	/// <summary>The maximum number of bytes accepted for a single content file's data.</summary>
	public const int MaxFileSize = 200_000_000;
}
