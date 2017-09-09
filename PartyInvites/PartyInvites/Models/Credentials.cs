using System.ComponentModel.DataAnnotations;
namespace PartyInvites.Models
{
	public class Credentials
	{
		[Required(ErrorMessage = "Please enter your email address")]
		[RegularExpression(".+\\@.+\\..+",
			ErrorMessage = "Please enter a valid email address")]
		public string Email { get; set; }
	}
}
