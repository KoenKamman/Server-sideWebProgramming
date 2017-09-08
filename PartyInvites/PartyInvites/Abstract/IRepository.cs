using System.Collections.Generic;
using PartyInvites.Models;

namespace PartyInvites.Abstract
{
    public interface IRepository
    {
	    IEnumerable<GuestResponse> GuestResponses { get; }

	    void AddResponse(GuestResponse response);
    }
}
