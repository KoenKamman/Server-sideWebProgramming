using System.Collections.Generic;
using System.Linq;
using PartyInvites.Abstract;

namespace PartyInvites.Models
{
	public class EfGuestResponseRepository : IRepository
	{
		private readonly DatabaseContext _context;

		public EfGuestResponseRepository(DatabaseContext context)
		{
			_context = context;
		}
		
		public IEnumerable<GuestResponse> GetAllResponses()
		{
			return _context.Responses;
		}

		public bool AddResponse(GuestResponse response)
		{
			_context.Responses.Add(response);
			_context.SaveChanges();
			return true;
		}

		public GuestResponse GetGuestResponse(string email)
		{
			var response = from c in _context.Credentials
				join r in _context.Responses on c.Id equals r.GuestResponseId
				where c.Email.Equals(email)
				select r;
			return response.SingleOrDefault();
		}

		public bool UpdateGuestResponse(GuestResponse guestResponse)
		{
			var response = (from c in _context.Credentials
				join r in _context.Responses on c.Id equals r.GuestResponseId
				where c.Email.Equals(guestResponse.Credential.Email)
				select r).SingleOrDefault();

			response.Address = guestResponse.Address;
			response.Name = guestResponse.Name;
			response.Phone = guestResponse.Phone;
			response.WillAttend = guestResponse.WillAttend;

			_context.SaveChanges();
			return true;
		}

		public string GetEmail(GuestResponse guestResponse)
		{
			var email = (from r in _context.Responses
				join c in _context.Credentials on r.GuestResponseId equals c.Id
				where guestResponse.GuestResponseId.Equals(c.Id)
				select c.Email).SingleOrDefault();
			return email;
		}
	}
}
