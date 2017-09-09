using System.Collections.Generic;
using System.Linq;
using PartyInvites.Abstract;

namespace PartyInvites.Models
{
	public class GuestResponseRepository : IRepository
	{
		private readonly List<GuestResponse> _responses = new List<GuestResponse>();

		public IEnumerable<GuestResponse> GuestResponses => _responses;

		public bool AddResponse(GuestResponse response)
		{
			_responses.Add(response);
			return true;
		}

		public GuestResponse GetGuestResponse(string email)
		{
			var response = GuestResponses.SingleOrDefault(a => a.Email == email);
			return response;
		}
	}
}
