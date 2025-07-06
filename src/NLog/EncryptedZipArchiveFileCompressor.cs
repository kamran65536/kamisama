using ICSharpCode.SharpZipLib.Zip;
using NLog.Targets;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.NLog;

/// <summary>
/// Password function delegate
/// </summary>
/// <param name="fileName"></param>
/// <param name="archiveFileName"></param>
/// <returns></returns>
public delegate string PasswordFunc(string fileName, string archiveFileName);

/// <summary>
/// Encrypted Zip Archive inspired by NLog ZipArchiveFileCompressor
/// </summary>
/// <remarks>
/// constructor
/// </remarks>
/// <param name="passwordFunc">password based on current file name</param>
/// <param name="compressionMethod">Compression method used by SharpZipLib library</param>
[ExcludeFromCodeCoverage]
public class EncryptedZipArchiveFileCompressor(PasswordFunc passwordFunc, CompressionMethod compressionMethod = CompressionMethod.BZip2) : IFileCompressor
{
	private readonly PasswordFunc passwordFunc = passwordFunc;

	/// <summary>
	/// Implements <see cref="IFileCompressor.CompressFile(string, string)"/> using the .Net4.5 specific <see cref="System.IO.Compression.ZipArchive"/>
	/// </summary>
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
