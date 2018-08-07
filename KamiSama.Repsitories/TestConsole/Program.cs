using System;
using System.Linq;
using KamiSama.Repositories;
using KamiSama.Repositories.EntityFramework;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new KamranDbContext())
			{
				var repository = new DbRepository<Kamran>(db);

				Console.WriteLine(repository.GetAll().Count());
			}
		}
	}
}
