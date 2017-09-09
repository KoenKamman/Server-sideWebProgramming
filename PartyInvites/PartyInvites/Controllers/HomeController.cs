using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;
using PartyInvites.Abstract;

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
		public ViewResult Login(GuestResponse guestResponse)
		{
			ModelState.Clear();

			if (guestResponse.Email == null)
			{
				return View();
			}

			var response = _repository.GetGuestResponse(guestResponse.Email);
			if (response != null)
			{
				guestResponse = response;
			}
			return View("RsvpForm", guestResponse);
		}

		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{
				if (_repository.GetGuestResponse(guestResponse.Email) != null)
				{
					_repository.UpdateGuestResponse(guestResponse);
				}
				else
				{
					_repository.AddResponse(guestResponse);
				}
				return View("Thanks", guestResponse);
			}
			else
			{
				// there is a validation error
				return View(guestResponse);
			}
		}

		public ViewResult ListResponses()
		{
			return _repository.GuestResponses.Any() ? View(_repository.GuestResponses) : View("NoResponses");
		}
	}
}
