using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PartyInvites.Models
{
	public static class IdentitySeedData
	{
		private const string AdminUser = "Admin";
		private const string AdminPassword = "Welkom1";

		public static async void EnsurePopulated(IApplicationBuilder app)
		{
			var userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();
			var user = await userManager.FindByIdAsync(AdminUser);

			if (user != null) return;

			user = new IdentityUser("Admin");
			await userManager.CreateAsync(user, AdminPassword);
		}
	}
}
