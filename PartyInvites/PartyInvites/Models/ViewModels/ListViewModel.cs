using System.Collections.Generic;

namespace PartyInvites.Models.ViewModels
{
    public class ListViewModel
    {
		public IEnumerable<GuestResponse> GuestResponses { get; set; }
		public bool? FilterIsAttending { get; set; }
    }
}
