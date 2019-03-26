using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
				db.Database.Log = Console.WriteLine;

				var repository = new DbRepository<Kamran>(db);

				var kamran = repository.FirstOrDefault(x => true);
				kamran.Name = "Kami3";

				repository.Update(kamran);
			}
		}
	}
}
