using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
	    [ForeignKey("Credential")]
		public int GuestResponseId;

		[Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Please enter your address")]
		public string Address { get; set; }
        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }

		public virtual Credential Credential { get; set; }
    }
}
