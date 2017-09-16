using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;
using PartyInvites.Abstract;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRepository _repository;

		public HomeController(IRepository repo)
		{
			_repository = repo;
		}

		public ViewResult Index()
		{
			return View("Index");
		}

		[HttpGet]
		public ViewResult Login()
		{
			return View();
		}

		[HttpPost]
		public ViewResult Login(Credential credentials)
		{
			//Validation Error
			if (!ModelState.IsValid) return View(credentials);

			var response = _repository.GetGuestResponse(credentials.Email) ?? new GuestResponse();
			response.Credential = credentials;
			return View("RsvpForm", response);
		}

		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			//Validation Error
			if (!ModelState.IsValid) return View(guestResponse);

			if (_repository.GetGuestResponse(guestResponse.Credential.Email) != null)
			{
				_repository.UpdateGuestResponse(guestResponse);
			}
			else
			{
				_repository.AddResponse(guestResponse);
			}
			return View("Thanks", guestResponse);
		}

		public ViewResult ListResponses(bool? filterIsAttending)
		{
			var viewmodel = new ListViewModel
			{
				GuestResponses = _repository.GetAllResponses().Where(r => filterIsAttending == null || r.WillAttend == filterIsAttending),
				FilterIsAttending = filterIsAttending
			};

			return viewmodel.GuestResponses.Any() ? View(viewmodel) : View("NoResponses");
		}
	}
}
