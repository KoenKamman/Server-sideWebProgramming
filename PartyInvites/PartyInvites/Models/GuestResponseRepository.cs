using System.Collections.Generic;
using System.Linq;
using PartyInvites.Abstract;

namespace PartyInvites.Models
{
	public class GuestResponseRepository : IRepository
	{
		private readonly List<GuestResponse> _responses = new List<GuestResponse>();

		public IEnumerable<GuestResponse> GetAllResponses()
		{
			return _responses;
		}

		public bool AddResponse(GuestResponse response)
		{
			_responses.Add(response);
			return true;
		}

		public GuestResponse GetGuestResponse(string email)
		{
			var response = GetAllResponses().SingleOrDefault(a => a.Credential.Email == email);
			return response;
		}

		public bool UpdateGuestResponse(GuestResponse guestResponse)
		{
			var response = GetGuestResponse(guestResponse.Credential.Email);
			response.Credential.Email = guestResponse.Credential.Email;
			response.Address = guestResponse.Address;
			response.Name = guestResponse.Name;
			response.Phone = guestResponse.Phone;
			response.WillAttend = guestResponse.WillAttend;
			return true;
		}

		public string GetEmail(GuestResponse guestResponse)
		{
			return guestResponse.Credential.Email;
		}
	}
}
