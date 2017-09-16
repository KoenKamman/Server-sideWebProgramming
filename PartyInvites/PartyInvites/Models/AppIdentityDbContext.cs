using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace PartyInvites.Models
{
	public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
	{
		public AppIdentityDbContext(DbContextOptions options)
			: base(options) { }
	}
}