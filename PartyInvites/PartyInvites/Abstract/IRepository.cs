using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Models;

namespace PartyInvites.Abstract
{
    public interface IRepository
    {
	    IEnumerable<GuestResponse> GuestResponses { get; }

	    void AddResponse(GuestResponse response);
    }
}
