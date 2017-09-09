using System.ComponentModel.DataAnnotations;
namespace PartyInvites.Models
{
	public class Credential
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please enter your email address")]
		[RegularExpression(".+\\@.+\\..+",
			ErrorMessage = "Please enter a valid email address")]
		public string Email { get; set; }

		public virtual GuestResponse GuestResponse { get; set; }
	}
}
