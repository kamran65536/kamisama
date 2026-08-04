using KamiSama.Modules.Identity.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace KamiSama.Modules.Identity.Repositories.Database.Postgresql;
internal class PostgresqlKamiSamaIdentityDbContext(DbContextOptions<PostgresqlKamiSamaIdentityDbContext> options) : KamiSamaIdentityDbContext(options)
{
}
