using Ionic.Zip;
using NLog.Targets;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace KamiSama.Extensions.NLog
{
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
	[ExcludeFromCodeCoverage]
	public class EncryptedZipArchiveFileCompressor : IFileCompressor
	{
		private readonly PassswordFunc passwordFunc;
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="passwordFunc">password based on current file name</param>
		public EncryptedZipArchiveFileCompressor(PassswordFunc passwordFunc)
		{
			
			this.passwordFunc = passwordFunc;
		}
		/// <summary>
		/// Implements <see cref="IFileCompressor.CompressFile(string, string)"/> using the .Net4.5 specific <see cref="System.IO.Compression.ZipArchive"/>
		/// </summary>
		public void CompressFile(string fileName, string archiveFileName)
		{
			using (var zipFile = new ZipFile())
			{
				zipFile.Password = passwordFunc(fileName, archiveFileName);

				var file = new FileInfo(fileName);
				zipFile.AddEntry(file.Name, File.ReadAllBytes(file.FullName));

				zipFile.Save(archiveFileName);
			}
		}
	}
}
