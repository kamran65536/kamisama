using Ionic.Zip;
using NLog.Targets;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.NLog;

/// <summary>
/// Password function delegate
/// </summary>
/// <param name="fileName"></param>
/// <param name="archiveFileName"></param>
/// <returns></returns>
public delegate string PassswordFunc(string fileName, string archiveFileName);

/// <summary>
/// Encrypted Zip Archive ispired by NLog ZipArchiveFileCompressor
/// </summary>
/// <remarks>
/// constructor
/// </remarks>
/// <param name="passwordFunc">password based on current file name</param>
[ExcludeFromCodeCoverage]
public class EncryptedZipArchiveFileCompressor(PassswordFunc passwordFunc) : IFileCompressor
{
	private readonly PassswordFunc passwordFunc = passwordFunc;

	/// <summary>
	/// Implements <see cref="IFileCompressor.CompressFile(string, string)"/> using the .Net4.5 specific <see cref="System.IO.Compression.ZipArchive"/>
	/// </summary>
	public void CompressFile(string fileName, string archiveFileName)
	{
		using var zipFile = new ZipFile();
		
		zipFile.Password = passwordFunc(fileName, archiveFileName);

		var file = new FileInfo(fileName);
		zipFile.AddEntry(file.Name, File.ReadAllBytes(file.FullName));

		zipFile.Save(archiveFileName);
	}
}
