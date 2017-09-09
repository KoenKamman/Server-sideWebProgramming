using System.Collections.Generic;
using PartyInvites.Models;

namespace PartyInvites.Abstract
{
    public interface IRepository
    {
	    IEnumerable<GuestResponse> GetAllResponses();

	    bool AddResponse(GuestResponse response);

	    GuestResponse GetGuestResponse(string email);

	    bool UpdateGuestResponse(GuestResponse response);

	    string GetEmail(GuestResponse guestResponse);
    }
}
