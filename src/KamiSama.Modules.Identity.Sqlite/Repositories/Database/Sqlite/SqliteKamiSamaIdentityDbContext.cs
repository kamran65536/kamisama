using KamiSama.Modules.Identity.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Identity.Repositories.Database.Sqlite;
internal class SqliteKamiSamaIdentityDbContext(DbContextOptions<SqliteKamiSamaIdentityDbContext> options) 
	: KamiSamaIdentityDbContext(options)
{
}
