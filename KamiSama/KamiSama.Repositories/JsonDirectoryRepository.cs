using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KamiSama.Extenders;

namespace KamiSama.Repositories
{
	public class JsonDirectoryRepository<_UnitOfWorkType, _EntityType> : CachedRepository<_UnitOfWorkType, _EntityType>
	{
		public string DirectoryPath { get; }
		public string SearchPattern { get; }
		public SearchOption SearchOption { get; }

		public JsonDirectoryRepository(string directoryPath, string searchPattern, SearchOption searchOption, TimeSpan refreshInterval)
			: base(refreshInterval)
		{
			this.DirectoryPath = directoryPath;
			this.SearchOption = searchOption;
			this.SearchPattern = searchPattern;
		}
		private IEnumerable<_EntityType> JsonDeserializeFromDirectory(string direcotry, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
		{
			var allFiles = Directory.GetFiles(direcotry, searchPattern, searchOption);

			foreach (var filePath in allFiles)
				yield return File.ReadAllText(filePath).DeserializeFromJson<_EntityType>();
		}
		protected override _EntityType[] LoadItems(_UnitOfWorkType unitOfWork)
			=> JsonDeserializeFromDirectory(DirectoryPath, SearchPattern, SearchOption)
			.ToArray();
	}
}
