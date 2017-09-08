using System.Collections.Generic;
using PartyInvites.Abstract;

namespace PartyInvites.Models
{
	public class GuestResponseRepository : IRepository
	{
		private readonly List<GuestResponse> _responses = new List<GuestResponse>();

		public IEnumerable<GuestResponse> GuestResponses => _responses;

		public void AddResponse(GuestResponse response)
		{
			_responses.Add(response);
		}
	}
}
