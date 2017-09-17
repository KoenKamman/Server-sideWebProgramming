using Microsoft.EntityFrameworkCore;

namespace PartyInvites.Models
{
    public class DatabaseContext : DbContext
    {
	    public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base (options) {}

	    public DbSet<GuestResponse> Responses { get; set; }
		public DbSet<Credential> Credentials { get; set; }
    }
}
