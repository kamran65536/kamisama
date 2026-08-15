using ICSharpCode.SharpZipLib.Zip;
using NLog.Targets;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.NLog;

/// <summary>
/// Resolves the password used when a log file is added to a ZIP archive.
/// </summary>
/// <param name="fileName">The path of the log file being archived.</param>
/// <param name="archiveFileName">The path of the ZIP archive being created or updated.</param>
/// <returns>The password SharpZipLib uses to encrypt the archive entry.</returns>
public delegate string PasswordFunc(string fileName, string archiveFileName);

/// <summary>
/// Implements NLog archive compression by adding log files to password-protected ZIP archives with SharpZipLib.
/// Assign an instance to <see cref="ConcurrentFileTarget.FileCompressor"/> when encrypted archive entries are required.
/// </summary>
/// <remarks>
/// The password callback runs for each compression request and should obtain secrets from secure configuration.
/// </remarks>
/// <param name="passwordFunc">A callback that supplies the password for the source file and destination archive.</param>
/// <param name="compressionMethod">The SharpZipLib compression method used for the new archive entry.</param>
[ExcludeFromCodeCoverage]
public class EncryptedZipArchiveFileCompressor(PasswordFunc passwordFunc, CompressionMethod compressionMethod = CompressionMethod.BZip2) : IFileCompressor
{
	private readonly PasswordFunc passwordFunc = passwordFunc;

	/// <summary>
	/// Creates or opens the destination ZIP archive, applies the callback-provided password, and adds the source file with the configured compression method.
	/// </summary>
	/// <param name="fileName">The path of the log file to add to the archive.</param>
	/// <param name="archiveFileName">The path of the ZIP archive to create or update.</param>
	public void CompressFile(string fileName, string archiveFileName)
	{
		using var zipFile = File.Exists(archiveFileName) ? new ZipFile(archiveFileName) : ZipFile.Create(archiveFileName);

		zipFile.Password = passwordFunc(fileName, archiveFileName);
		var file = new FileInfo(fileName);

		zipFile.BeginUpdate();
		zipFile.Add(file.FullName, compressionMethod);
		zipFile.CommitUpdate();
	}
}
